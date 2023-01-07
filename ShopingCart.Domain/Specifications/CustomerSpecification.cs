using ShopingCart.Domain.Core.Specifications;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Domain.Specifications
{
    public static class CustomerSpecification
    {
        public static BaseSpecification<Customer> FirstOrDefaultCustomers(string CustomerID)
        {
            return new BaseSpecification<Customer>(s => s.CustomerID == CustomerID);
        }

        public static BaseSpecification<Customer> FindCustomerAsync(string CustomerID)
        {
            return new BaseSpecification<Customer>(s => s.CustomerID == CustomerID);
        }

    }
}
