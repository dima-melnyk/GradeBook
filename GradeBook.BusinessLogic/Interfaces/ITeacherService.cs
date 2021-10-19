using GradeBook.BusinessLogic.Models;
using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface ITeacherService
    {
        Task CreateTeacher(Teacher newTeacher);
        Task DeleteTeacher(int id);
        Task<TeacherToView> GetTeacher(int id);
    }
}
