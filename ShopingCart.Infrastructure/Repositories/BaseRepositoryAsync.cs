using Microsoft.EntityFrameworkCore;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Domain.Core.Models;
using ShopingCart.Domain.Core.Specifications;
using ShopingCart.Infrastructure.Repositories;

namespace ShopingCart.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly CartDbContext _entity;
        public BaseRepository(CartDbContext entity)
        {
            _entity = entity;
        }
        public  async Task<T> GetById(int id)
        {
            return await _entity.Set<T>().FindAsync(id);
        }
        public async Task<T> FindAsync(string code)
        {
            return await _entity.Set<T>().FindAsync(code);
        }
        public async Task<IList<T>> AllListAsync()
        {
            return await _entity.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
           return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
          return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
           await _entity.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _entity.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _entity.Set<T>().Update(entity);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_entity.Set<T>().AsQueryable(), specification);
        }
        
    }
}
