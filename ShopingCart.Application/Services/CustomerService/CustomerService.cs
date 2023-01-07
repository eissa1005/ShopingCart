using AutoMapper;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.CategoryDTOs;
using ShopingCart.Application.Models.DTOs.CustomerDTOs;
using ShopingCart.Domain.Entities;
using ShopingCart.Domain.Specifications;

namespace ShopingCart.Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork uow;
        private readonly ILoggerService logService;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork uow, ILoggerService logService, IMapper mapper)
        {
            this.uow = uow;
            this.logService = logService;
            this.mapper = mapper;
        }

        public async Task<CustomerViewModelRes> GetCustomerById(int ID)
        {
            var customer = await uow.Repository<Customer>().GetById(ID);
            var custoerDto = mapper.Map<CustomerViewModelRes>(customer);
            return custoerDto;
        }
        public async Task<CustomerViewModelRes> FindCustomerAsync(string customerID)
        {
            var customer = await uow.Repository<Customer>().FindAsync(customerID);
            var customerDto = mapper.Map<CustomerViewModelRes>(customer);
            return customerDto;
        }
        public async Task<CustomerViewModelRes> FirstOrDefaultCustomer(string customerID)
        {
            var customerSpecification = CustomerSpecification.FirstOrDefaultCustomers(customerID);
            var customer = await uow.Repository<Customer>().FirstOrDefaultAsync(customerSpecification);
            var customerDto = mapper.Map<CustomerViewModelRes>(customer);
            return customerDto;
        }

        public async Task<IReadOnlyCollection<CustomerViewModelRes>> GetAllCustomers()
        {
            var lst = await uow.Repository<Customer>().AllListAsync();
            var lstCustomerView = new List<CustomerViewModelRes>();
            foreach (var customer in lst)
            {
                lstCustomerView.Add(new CustomerViewModelRes() { Data = CustomerDTOs.Create(customer) });
            }

            return lstCustomerView;
        }
        public async Task<int> AddCustomer(CustomerViewModelReq request)
        {
            var customer = mapper.Map<Customer>(request);
            if (customer == null)
            {
                logService.LogError($"can't add empty customer {typeof(CustomerService)} ");
                return await Task.FromResult(0);
            }

            await uow.Repository<Customer>().AddAsync(customer);
            return await uow.SaveChangesAsync();

        }
        public async Task<int> UpdateCustomer(CustomerViewModelReq request)
        {
            var customer = mapper.Map<Customer>(request);
            if (customer == null || customer.ID == 0)
            {
                logService.LogError($"Can't Update empty Customer {typeof(CustomerService)} ");
                return await Task.FromResult(0);
            }
            uow.Repository<Customer>().Update(customer);
            return await uow.SaveChangesAsync();

        }
        public async Task<int> DeleteCustomer(CustomerViewModelReq request)
        {
            var customerTDo = await FindCustomerAsync(request.CustomerID);
            var custoemer = mapper.Map<Customer>(customerTDo);
            if(custoemer == null)
            {
                logService.LogError($"Can't Delete empty Customer {typeof(CustomerService)}");
                return await Task.FromResult(0);
            }
             uow.Repository<Customer>().Delete(custoemer);
            return await uow.SaveChangesAsync();
        }


    }
}
