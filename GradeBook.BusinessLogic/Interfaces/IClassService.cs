using GradeBook.Models.Read;
using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IClassService
    {
        Task CreateClass(Class createClass);
        Task DeleteClass(int id);
        Task<ClassModel> GetClass(int id);
    }
}
