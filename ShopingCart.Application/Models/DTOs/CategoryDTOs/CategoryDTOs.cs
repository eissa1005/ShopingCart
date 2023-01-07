using ShopingCart.Domain.Entities;

namespace ShopingCart.Application.Models.DTOs.CategoryDTOs
{
    public class CategoryDTOs
    {
        public int ID { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public CategoryDTOs() { }

        private CategoryDTOs(Category category)
        {
            ID = category.ID;
            CategoryID = category.CategoryID;
            CategoryName = category.CategoryName;
            Description = category.Description;
        }

        public static CategoryDTOs Create(Category category)
        {
            return new CategoryDTOs(category);
        }
    }
}
