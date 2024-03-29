﻿using ShopingCart.Domain;
using ShopingCart.Domain.Core.Models;
using ShopingCart.Domain.Core.Specifications;

namespace ShopingCart.Application.Core.Repositories
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task<T> GetById(int id);
        Task<T> FindAsync(string code);
        Task<IList<T>> AllListAsync();
        Task<IList<T>> ListAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync();
        Task<T> FirstOrDefaultAsyncSpec(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
