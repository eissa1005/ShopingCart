using Microsoft.AspNetCore.Mvc.Rendering;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Application.Models.DTOs.ItemsDTOs
{
    public class ItemsViewModelReq
    {
        public int ID { get; set; }
        public string CategoryID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public int Discount { get; set; }
        public decimal Total { get; set; }
        public string ImagePath { get; set; }
        public virtual IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}
