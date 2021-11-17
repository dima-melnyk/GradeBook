using GradeBook.Models.Read;
using GradeBook.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IPupilService
    {
        Task UpdatePupil(UserClass updatePupil);
        Task<PupilModel> GetPupil(int id);
        Task<IEnumerable<PupilModel>> GetPupilsByClass(int classId);
    }
}
