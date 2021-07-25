using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Repositories.Repositories.Contracts;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Exceptions.Base;
using System;

namespace Repositories.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Protected Properties

        protected readonly MunicipalitiesDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        #endregion

        #region Constructors

        public BaseRepository(MunicipalitiesDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        #endregion

        #region Get

        public virtual async Task<T> GetByKey(object key)
        {
            var entity = await _dbSet.FindAsync(key);

            return entity;
        }

        #endregion

        #region Add

        public virtual async Task Add(T entity)
        {
            if (entity == null) return;

            try
            {
                _dbSet.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new MunicipalitiesException(MunicipalitiesExceptionCodes.Base.ErrorAdding, ex);
            }
        }

        #endregion

        #region Update

        public virtual async Task Update(T entity)
        {
            if (entity == null) return;

            try
            {
                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new MunicipalitiesException(MunicipalitiesExceptionCodes.Base.ErrorUpdating, ex);
            }
        }

        #endregion
    }
}
