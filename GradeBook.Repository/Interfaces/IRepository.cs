using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}