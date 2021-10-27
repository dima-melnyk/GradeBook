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

namespace GradeBook.BusinessLogic.Services
{
    public class GradeService : IGradeService
    {
        private readonly IEntityRepository<Grade> _repository;
        private readonly IMapper _mapper;

        public GradeService(IEntityRepository<Grade> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task CreateGrade(Grade newGrade) => _repository.AddAsync(newGrade);

        public Task UpdateGrade(Grade updateGrade) => _repository.UpdateAsync(updateGrade);

        public Task DeleteGrade(int id) => _repository.RemoveByIdAsync(id);

        public async Task<GradeToView> GetGrade(int id, IEnumerable<Claim> claims)
        {
            var model = await _repository.GetByIdAsync(id);
            var role = claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultRoleClaimType).Value;

            if (!(int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value) == model.Pupil.UserId 
                || role == "Teacher" || role == "Admin"))
                throw new UnauthorizedAccessException("User doesn\'t have access to this information");
            return _mapper.Map<GradeToView>(model);
        }

        public IEnumerable<GradeToView> GetGrades(GradeQuery query) => _repository.GetAll()
                .Where(g => g.Pupil.Id == query.PupilId || query.PupilId == null)
                .Where(g => g.Lesson.SubjectId == query.SubjectId || query.SubjectId == null)
                .Where(g => g.Lesson.ClassId == query.ClassId || query.ClassId == null)
                .Where(g => g.Lesson.Date.Equals(query.Date) || query.Date == null)
                .Select(_mapper.Map<GradeToView>)
                .ToList();
    }
}
