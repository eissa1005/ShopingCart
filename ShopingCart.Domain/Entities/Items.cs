using ShopingCart.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopingCart.Domain.Entities
{
    public class Items : IBaseEntity
    {
        public Items() 
        { 
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string CategoryID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal Total { get; set; }
        public string ImagePath { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
        public virtual Category Categorie { get; set; }
       



    }
}
