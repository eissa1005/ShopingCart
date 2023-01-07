using ShopingCart.Domain.Core.Models;
using ShopingCart.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopingCart.Domain.Entities
{
    public class User : BaseEntity
    {
        public User() 
        {
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserStatus Status { get; set; }  
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Roles { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public ICollection<CartItem> CartItems { get; set; }
       

    }
}
