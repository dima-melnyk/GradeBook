using GradeBook.Models.Read;
using GradeBook.Models.Write;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IAdminService
    {
        Task UpdateRole(UpdateRole model);
        Task<IEnumerable<UserModel>> GetUsers();
    }
}
