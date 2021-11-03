using GradeBook.DataAccess.Entities.Base;
using GradeBook.DataAccess.Entities.Base.Interface;
using System.Threading.Tasks;


namespace GradeBook.Repository.Interfaces
{
    public interface IEntityRepository<TEntity> : IRepository<TEntity> where TEntity: class, IEntityBase
    {
        Task<TEntity> GetByIdAsync(int id);
        Task RemoveByIdAsync(int id);
    }
}
