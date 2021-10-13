using GradeBook.BusinessLogic.DTOs;
using GradeBook.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IPupilService
    {
        Task CreatePupil(CreatePupilDTO newPupil);
        Task UpdatePupil(int id, UpdatePupilDTO updatePupil);
        Task DeletePupil(int id);
        Task<PupilDTO> GetPupil(int id);
        List<PupilDTO> GetPupilsByClass(int classId);
    }
}
