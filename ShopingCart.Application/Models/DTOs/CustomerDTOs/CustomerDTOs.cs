using ShopingCart.Domain.Entities;

namespace ShopingCart.Application.Models.DTOs.CustomerDTOs
{
    public class CustomerDTOs
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public CustomerDTOs() { }
        internal CustomerDTOs(Customer customer)
        {
            ID = customer.ID;
            CustomerID = customer.CustomerID;
            CustomerName = customer.CustomerName;
            Address1 = customer.Address1;
            Address2 = customer.Address2;
            City = customer.City;
            Country = customer.Country;
            Phone = customer.Phone;
            Email = customer.Email;
        }

        public static CustomerDTOs Create(Customer customer)
        {
            return new CustomerDTOs(customer);
        }
    }
}
