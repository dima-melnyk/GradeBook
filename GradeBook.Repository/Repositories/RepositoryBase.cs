using System;
using System.Linq;
using System.Threading.Tasks;
using GradeBook.DataAccess;
using GradeBook.Repository.Interfaces;

namespace BookStore.Repository.Repositories
{

    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
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

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                DbContext.Add(entity);
                DbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be saved: {ex.Message}", ex);
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

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                DbContext.Update(entity);
                DbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be updated: {ex.Message}", ex);
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

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(Remove)} entity must not be null");

            try
            {
                DbContext.Remove(entity);
                DbContext.SaveChangesAsync();
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
    }
}