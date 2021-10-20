using GradeBook.Models.Read;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IGradeService
    {
        Task CreateGrade(Grade newGrade);
        Task UpdateGrade(Grade updateGrade);
        Task DeleteGrade(int id);
        Task<GradeToView> GetGrade(int id);
        IEnumerable<GradeToView> GetGrades(GradeQuery query);
    }
}
