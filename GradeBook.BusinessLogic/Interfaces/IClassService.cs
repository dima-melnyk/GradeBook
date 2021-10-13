using GradeBook.BusinessLogic.Models;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IClassService
    {
        Task CreateClass(CreateClass createClass);
        Task DeleteClass(int id);
        Task<ClassToView> GetClass(int id);
    }
}
