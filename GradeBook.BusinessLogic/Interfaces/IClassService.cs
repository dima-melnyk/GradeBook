using GradeBook.BusinessLogic.DTOs;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IClassService
    {
        Task CreateClass(CreateClassDTO createClass);
        Task DeleteClass(int id);
        Task<ClassDTO> GetClass(int id);
    }
}
