using BookStore.Repository.Repositories;
using GradeBook.DataAccess;
using GradeBook.DataAccess.Entities.Base;
using GradeBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GradeBook.Repository.Repositories
{
    class EntityRepository<TEntity> : RepositoryBase<TEntity>, IEntityRepository<TEntity> where TEntity: EntityBase
    {
        public EntityRepository(GBContext dbContext) : base(dbContext) { }
        
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(e => id == e.Id);
        }
    }
}
