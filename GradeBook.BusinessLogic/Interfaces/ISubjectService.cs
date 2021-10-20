using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface ISubjectService
    {
        Task CreateSubject(Subject subject);
    }
}
