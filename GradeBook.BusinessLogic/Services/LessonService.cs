using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class LessonService : ILessonService
    {
        private readonly IEntityRepository<Lesson> _repository;
        private readonly IEntityRepository<Grade> _gradeRepository;
        private readonly IMapper _mapper;

        public LessonService(IEntityRepository<Lesson> repository, IEntityRepository<Grade> gradeRepository, IMapper mapper)
        {
            _repository = repository;
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public Task CreateLesson(Lesson newLesson) => _repository.AddAsync(newLesson);

        public async Task DeleteLesson(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            await _gradeRepository.RemoveRange(model.Grades);
            await _repository.RemoveAsync(model);
        }

        public async Task<LessonModel> GetLesson(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<LessonModel>(model);
        }

        public IEnumerable<LessonModel> GetLessons(LessonQuery query) => _repository.GetAll()
                .Where(l => l.TeacherId == query.TeacherId || query.TeacherId == null)
                .Where(l => l.ClassId == query.ClassId || query.ClassId == null)
                .Where(l => l.SubjectId == query.SubjectId || query.SubjectId == null)
                .Where(l => l.Date.Equals(query.Date) || query.Date == null)
                .Select(l => _mapper.Map<LessonModel>(l))
                .ToList();
    }
}
