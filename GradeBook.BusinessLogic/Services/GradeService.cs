using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.BusinessLogic.Services
{
    public class GradeService : IGradeService
    {
        private readonly IEntityRepository<Grade> _repository;
        private readonly IEntityRepository<Pupil> _pupilRepository;
        private readonly IMapper _mapper;

        public GradeService(IEntityRepository<Grade> repository, IMapper mapper, IEntityRepository<Pupil> pupilRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pupilRepository = pupilRepository;
        }

        public Task CreateGrade(Grade newGrade) => _repository.AddAsync(newGrade);

        public Task UpdateGrade(Grade updateGrade) => _repository.UpdateAsync(updateGrade);

        public Task DeleteGrade(int id) => _repository.RemoveByIdAsync(id);

        public async Task<GradeModel> GetGrade(int id, IEnumerable<Claim> claims)
        {
            var model = await _repository.GetByIdAsync(id);
            var roles = claims.Where(c => c.Type == ClaimsIdentity.DefaultRoleClaimType)
                .Select(c => c.Value);

            var pupilId = await GetPupilId(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (!(pupilId == model.Pupil.Id || IsUserInCorrectRole(roles)))
                throw new MethodAccessException("User doesn\'t have access to this information");
            return _mapper.Map<GradeModel>(model);
        }

        public IEnumerable<GradeModel> GetGrades(GradeQuery query) => _repository.GetAll()
                .Where(g => g.Pupil.Id == query.PupilId || query.PupilId == null)
                .Where(g => g.Lesson.SubjectId == query.SubjectId || query.SubjectId == null)
                .Where(g => g.Lesson.ClassId == query.ClassId || query.ClassId == null)
                .Where(g => g.Lesson.Date.Equals(query.Date) || query.Date == null)
                .Select(_mapper.Map<GradeModel>)
                .ToList();

        private bool IsUserInCorrectRole(IEnumerable<string> roles)
        {
            IEnumerable<string> correctRoles = new List<string> { "Teacher", "Admin" };
            return correctRoles.Intersect(roles).Any();
        }

        private Task<int> GetPupilId(string userId) => _pupilRepository.GetAll()
                .Where(p => p.UserId == int.Parse(userId))
                .Select(p => p.Id)
                .FirstOrDefaultAsync();
    }
}
