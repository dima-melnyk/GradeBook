using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Models;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateGrade(Grade newGrade)
        {
            await _repository.AddAsync(newGrade);
        }

        public async Task UpdateGrade(Grade updateGrade)
        {
            await _repository.UpdateAsync(updateGrade);
        }

        public async Task DeleteGrade(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(model);
        }

        public async Task<GradeToView> GetGrade(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<GradeToView>(model);
        }

        public List<GradeToView> GetGrades(GradeQuery query)
        {
            return _repository.GetAll()
                .Where(g => g.Pupil.Id == query.PupilId || query.PupilId == null)
                .Where(g => g.Lesson.SubjectId == query.SubjectId || query.SubjectId == null)
                .Where(g => g.Lesson.ClassId == query.ClassId || query.ClassId == null)
                .Where(g => g.Lesson.Date.Equals(query.Date) || query.Date == null)
                .Select(_mapper.Map<GradeToView>)
                .ToList();
        }
    }
}
