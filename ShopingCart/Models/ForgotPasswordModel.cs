using System.ComponentModel.DataAnnotations;

namespace ShopingCart.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
