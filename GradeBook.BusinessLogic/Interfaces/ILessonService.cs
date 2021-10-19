using GradeBook.DataAccess.Entities;
using GradeBook.BusinessLogic.Queries;
using System.Threading.Tasks;
using System.Collections.Generic;
using GradeBook.BusinessLogic.Models;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface ILessonService
    {
        Task CreateLesson(Lesson newLesson);
        Task DeleteLesson(int id);
        Task<LessonToView> GetLesson(int id);
        List<LessonToView> GetLessons(LessonQuery query);
    }
}
