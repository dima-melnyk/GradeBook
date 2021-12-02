using GradeBook.DataAccess.Entities;
using GradeBook.Models.Read;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface ISubjectService
    {
        Task CreateSubject(Subject subject);
        Task<IEnumerable<SubjectModel>> GetSubjects();
    }
}
