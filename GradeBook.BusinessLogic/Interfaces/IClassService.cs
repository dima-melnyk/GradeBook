using GradeBook.Models.Read;
using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IClassService
    {
        Task CreateClass(Class createClass);
        Task DeleteClass(int id);
        Task<ClassModel> GetClass(int id);
        IEnumerable<ClassModel> GetClasses();

    }
}
