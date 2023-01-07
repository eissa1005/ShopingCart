using ShopingCart.Domain.Entities;

namespace ShopingCart.Application.Models.DTOs.ItemsDTOs
{
    public class ItemsDTOs
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
        public virtual ICollection<Category> Categories { get; set; }

        public ItemsDTOs() { }
        internal ItemsDTOs(Items items)
        {
            ID = items.ID;
            CategoryID = items.CategoryID;
            ItemCode = items.ItemCode;
            ItemName = items.ItemName;
            Description = items.Description;
            Quantity = items.Quantity;
            ItemPrice = items.ItemPrice;
            Total = items.ItemPrice * items.Quantity;
            Discount= items.Discount;
            ImagePath = items.ImagePath;
            Categories = new HashSet<Category>();
            Categories = new HashSet<Category>();
        }

        public static ItemsDTOs Create(Items items)
        {
            return new ItemsDTOs(items);
        }

    }
}
