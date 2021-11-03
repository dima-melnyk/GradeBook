using GradeBook.Models.Read;
using GradeBook.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IPupilService
    {
        Task UpdatePupil(Pupil updatePupil);
        Task DeletePupil(int id);
        Task<PupilModel> GetPupil(int id);
        IEnumerable<PupilModel> GetPupilsByClass(int classId);
    }
}
