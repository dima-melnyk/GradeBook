using GradeBook.Models.Read;
using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface ITeacherManager
    {
        Task DeleteTeacher(int id);
        Task<TeacherToView> GetTeacher(int id);
    }
}
