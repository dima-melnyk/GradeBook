using BookStore.Repository.Repositories;
using GradeBook.DataAccess;
using GradeBook.DataAccess.Entities.Base;
using GradeBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.Repository.Repositories
{
    public class EntityRepository<TEntity> : RepositoryBase<TEntity>, IEntityRepository<TEntity> where TEntity: EntityBase
    {
        public EntityRepository(GBContext dbContext) : base(dbContext) { }
        
        public async Task<TEntity> GetByIdAsync(int id)
        {
            var model = await GetAll().FirstOrDefaultAsync(e => id == e.Id);
            if (model == null)
                throw new KeyNotFoundException($"Entity {typeof(TEntity)} with id:{id} does not found");
            return model;
        }
    }
}
