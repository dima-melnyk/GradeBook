using GradeBook.BusinessLogic.Models;
using GradeBook.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IPupilService
    {
        Task CreatePupil(Pupil newPupil);
        Task UpdatePupil(Pupil updatePupil);
        Task DeletePupil(int id);
        Task<PupilToView> GetPupil(int id);
        List<PupilToView> GetPupilsByClass(int classId);
    }
}
