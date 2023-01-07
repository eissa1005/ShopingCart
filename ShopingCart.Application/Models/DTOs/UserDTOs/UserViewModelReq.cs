using ShopingCart.Domain.Enums;

namespace ShopingCart.Application.Models.DTOs.UserDTOs
{
    public class UserViewModelReq
    {
        public int ID { get; set; }
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
        public List<string> Roles { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
