using ShopingCart.Domain.Core.Models;

namespace ShopingCart.Application.Models.DTOs.CategoryDTOs
{
    public class CategoryViewModelReq : BaseEntity
    {
        public int ID { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}
