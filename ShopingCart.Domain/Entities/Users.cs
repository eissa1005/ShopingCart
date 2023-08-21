using Microsoft.AspNetCore.Identity;
using ShopingCart.Domain.Core.Models;
using ShopingCart.Domain.Enums;

namespace ShopingCart.Domain.Entities
{
    public class Users : IdentityUser , IBaseEntity
    {
        public Users() 
        {
            CartItems = new HashSet<CartItem>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ID { get; set; }
        
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserStatus Status { get; set; }  
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePicture { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
       

    }
}
