using ShopingCart.Domain.Entities;

namespace ShopingCart.Application.Models.DTOs.CartItemDTOs
{
    public class CartItemDTOs
    {
        
        public int ID { get; set; }
        public string CartID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public string UserID { get; set; }
        public string ImagePath { get; set; }

        public CartItemDTOs() { }
        private CartItemDTOs(CartItem cartItem)
        {
            ID = cartItem.ID;
            CartID = cartItem.CartID;
            ItemCode = cartItem.ItemCode;
            ItemName = cartItem.ItemName;
            Quantity = cartItem.Quantity;
            UnitPrice = cartItem.UnitPrice;
            Discount = cartItem.Discount;
            Amount = cartItem.Amount;
            Total = cartItem.Quantity * cartItem.UnitPrice;
            UserID = cartItem.UserID;
            ImagePath = cartItem.ImagePath;
        }

        public static CartItemDTOs Create(CartItem cartItem)
        {
            return new CartItemDTOs(cartItem);
        }
    }
}
