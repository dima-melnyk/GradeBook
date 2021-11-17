using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradeBook.DataAccess;
using System;

namespace GradeBook.BusinessLogic.Services
{
    public class LessonService : ILessonService
    {
        private readonly GBContext _context;
        private readonly IMapper _mapper;

        public LessonService(GBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateLesson(Lesson newLesson)
        {
            await _context.AddAsync(newLesson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLesson(int id)
        {
            var model = await GetLessonFromContext(id);

            _context.RemoveRange(model.Grades);
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<LessonModel> GetLesson(int id)
        {
            return _mapper.Map<LessonModel>(await GetLessonFromContext(id));
        }

        public async Task<IEnumerable<LessonModel>> GetLessons(LessonQuery query) => (await _context.Lessons
                .Where(l => l.TeacherId == query.TeacherId || query.TeacherId == null)
                .Where(l => l.ClassId == query.ClassId || query.ClassId == null)
                .Where(l => l.SubjectId == query.SubjectId || query.SubjectId == null)
                .Where(l => l.Date.Equals(query.Date) || query.Date == null)
                .ToListAsync())
                .Select(l => _mapper.Map<LessonModel>(l));

        private async Task<Lesson> GetLessonFromContext(int id)
        {
            var model = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            return model ?? throw new ArgumentNullException(null, "Entity does not found");
        }
    }
}
