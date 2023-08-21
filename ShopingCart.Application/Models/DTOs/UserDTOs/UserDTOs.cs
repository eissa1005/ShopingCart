using ShopingCart.Domain.Entities;
using ShopingCart.Domain.Enums;

namespace ShopingCart.Application.Models.DTOs.UserDTOs
{
    public class UserDTOs
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserStatus Status { get; set; }
        public bool IsAdmin { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Roles { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        internal UserDTOs(Users user)
        {
            ID = user.Id;
            UserID = user.UserID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Status = user.Status;   
            Address = user.Address;
            City = user.City;
            Country = user.Country;
            Phone = user.Phone;
            UserName = user.UserName;
            Email = user.Email;
            Password = user.PasswordHash;
            
        }
        public static UserDTOs Create(Users user)
        {
            return new UserDTOs(user);
        }
    }
}
