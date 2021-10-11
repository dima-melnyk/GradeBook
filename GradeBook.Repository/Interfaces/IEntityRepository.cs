using GradeBook.DataAccess.Entities.Base;
using System.Threading.Tasks;


namespace GradeBook.Repository.Interfaces
{
    public interface IEntityRepository<TEntity> : IRepository<TEntity> where TEntity: EntityBase
    {
        Task<TEntity> GetByIdAsync(int id);
    }
}
