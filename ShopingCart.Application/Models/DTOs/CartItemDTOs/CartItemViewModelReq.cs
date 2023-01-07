namespace ShopingCart.Application.Models.DTOs.CartItemDTOs
{
    public class CartItemViewModelReq
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
    }
}
