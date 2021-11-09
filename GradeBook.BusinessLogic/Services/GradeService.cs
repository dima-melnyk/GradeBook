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
        private readonly IMapper _mapper;
        private readonly IEnumerable<string> _correctRoles = new List<string> { "Teacher", "Admin" };


        public GradeService(IEntityRepository<Grade> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task CreateGrade(Grade newGrade) => _repository.AddAsync(newGrade);

        public Task UpdateGrade(Grade updateGrade) => _repository.UpdateAsync(updateGrade);

        public Task DeleteGrade(int id) => _repository.RemoveByIdAsync(id);

        public async Task<GradeModel> GetGrade(int id, IEnumerable<Claim> claims)
        {
            var model = await _repository.GetByIdAsync(id);
            var roles = claims.Where(c => c.Type == ClaimsIdentity.DefaultRoleClaimType)
                .Select(c => c.Value);

            var pupilId = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (!(pupilId == model.Pupil.Id || IsUserInCorrectRole(roles)))
                throw new MethodAccessException("User doesn\'t have access to this information");
            return _mapper.Map<GradeModel>(model);
        }

        public async Task<IEnumerable<GradeModel>> GetGrades(GradeQuery query) => (await _repository.GetAll()
                .Where(g => g.Pupil.Id == query.PupilId || query.PupilId == null)
                .Where(g => g.Lesson.SubjectId == query.SubjectId || query.SubjectId == null)
                .Where(g => g.Lesson.ClassId == query.ClassId || query.ClassId == null)
                .Where(g => g.Lesson.Date.Equals(query.Date) || query.Date == null)
                .ToListAsync())
                .Select(_mapper.Map<GradeModel>);

        private bool IsUserInCorrectRole(IEnumerable<string> roles) => _correctRoles.Intersect(roles).Any();
    }
}
