using ShopingCart.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopingCart.Domain.Entities
{
    public class CartItem : IBaseEntity
    {
        public CartItem()
        {
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string CartID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CustomerID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int Amount { get; set; }
        public string UserID { get; set; }
        public string ImagePath { get; set; }
        public Users Users { get; set; }
        public Items Items { get; set; }
        public Customer Customer { get; set; }
    }

}
