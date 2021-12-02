using GradeBook.Models.Read;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IGradeService
    {
        Task CreateGrade(Grade newGrade);
        Task UpdateGrade(Grade updateGrade);
        Task DeleteGrade(int id);
        Task<GradeModel> GetGrade(int id, IEnumerable<Claim> claims);
        Task<IEnumerable<GradeModel>> GetGrades(GradeQuery query);
    }
}
