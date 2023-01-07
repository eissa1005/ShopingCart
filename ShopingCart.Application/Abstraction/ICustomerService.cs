using ShopingCart.Application.Models.DTOs.CustomerDTOs;
using ShopingCart.Domain.Core.Specifications;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Application.Abstraction
{
    public interface ICustomerService
    {
        Task<CustomerViewModelRes> GetCustomerById(int ID);
        Task<CustomerViewModelRes> FindCustomerAsync(string customerID);
        Task<IReadOnlyCollection<CustomerViewModelRes>> GetAllCustomers();
        Task<CustomerViewModelRes> FirstOrDefaultCustomer(string customerID);
        Task<int> AddCustomer(CustomerViewModelReq request);
        Task<int> UpdateCustomer(CustomerViewModelReq request);
        Task<int> DeleteCustomer(CustomerViewModelReq request);

    }
}
