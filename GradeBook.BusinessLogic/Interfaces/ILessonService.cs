using GradeBook.DataAccess.Entities;
using GradeBook.BusinessLogic.Queries;
using System.Threading.Tasks;
using System.Collections.Generic;
using GradeBook.Models.Read;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface ILessonService
    {
        Task CreateLesson(Lesson newLesson);
        Task DeleteLesson(int id);
        Task<LessonModel> GetLesson(int id);
        Task<IEnumerable<LessonModel>> GetLessons(LessonQuery query);
    }
}
