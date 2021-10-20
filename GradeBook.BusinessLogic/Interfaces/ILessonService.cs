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
        Task<LessonToView> GetLesson(int id);
        IEnumerable<LessonToView> GetLessons(LessonQuery query);
    }
}
