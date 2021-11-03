using GradeBook.DataAccess.Entities;
using GradeBook.DataAccess.Entities.Base;
using GradeBook.Models.Read;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IAdminService
    {
        Task Create<TEntity>(TEntity model) where TEntity: UserBase;
        IEnumerable<UserModel> GetUsers();
    }
}
