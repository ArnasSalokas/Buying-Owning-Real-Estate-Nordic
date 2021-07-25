﻿using System.Threading.Tasks;

namespace Repositories.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> GetByKey(object key);
        public Task Add(T entity);
        public Task Update(T entity);
    }
}
