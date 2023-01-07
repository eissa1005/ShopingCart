using ShopingCart.Application.Core.Repositories;
using ShopingCart.Domain.Core.Models;
namespace ShopingCart.Application.Core.Repositories
{
    public interface IUnitOfWork
    {

        Task<int> SaveChangesAsync();
        Task SaveChangesRollBack();
        IBaseRepository<T> Repository<T>() where T : BaseEntity;

    }
}
