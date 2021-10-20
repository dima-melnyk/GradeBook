using GradeBook.BusinessLogic.Models;
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
        List<GradeToView> GetGrades(GradeQuery query);
    }
}
