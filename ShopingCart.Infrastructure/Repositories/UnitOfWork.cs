using ShopingCart.Application.Core.Repositories;
using ShopingCart.Domain.Core.Models;

namespace ShopingCart.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CartDbContext _entities;
        private readonly Dictionary<Type, dynamic> _repository;
       

        public UnitOfWork(CartDbContext entities)
        {
            _entities = entities;
            _repository  = new Dictionary<Type, dynamic>(); ;
           
        }

        public IBaseRepository<T> Repository<T>() where T : BaseEntity
        {
            var contentType = typeof(T);
            if (_repository.ContainsKey(contentType))
            {
                return _repository[contentType];
            }

            var repositoryType = typeof(BaseRepository<>);
            var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _entities);
            _repository.Add(contentType, repository);

            return (IBaseRepository<T>)repository;
        }

        public async Task<int> SaveChangesAsync()
        {
           return  await _entities.SaveChangesAsync();
        }

        public async Task SaveChangesRollBack()
        {
            await _entities.Database.RollbackTransactionAsync();
        }
    }
}