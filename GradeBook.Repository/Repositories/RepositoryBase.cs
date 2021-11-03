using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeBook.DataAccess;
using GradeBook.DataAccess.Entities.Base.Interface;
using GradeBook.Repository.Interfaces;

namespace BookStore.Repository.Repositories
{

    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase
    {
        protected readonly GBContext DbContext;

        public RepositoryBase(GBContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return DbContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                await DbContext.AddAsync(entity);
                await DbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be saved: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                DbContext.Update(entity);
                await DbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be updated: {ex.Message}", ex);
            }
        }

        public async Task RemoveAsync(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(RemoveAsync)} entity must not be null");

            try
            {
                DbContext.Remove(entity);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be updated: {ex.Message}", ex);
            }
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ApplicationException($"{nameof(RemoveRange)} entities must not be null");

            try
            {
                DbContext.RemoveRange(entities);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entities)} could not be updated: {ex.Message}", ex);
            }
        }
    }
}