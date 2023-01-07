using ShopingCart.Domain.Core.Specifications;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Domain.Specifications
{
    public static class CategorySpecification
    {
        public static BaseSpecification<Category> GetFirstOrDefaultCategory(string CategoryID)
        {
            return new BaseSpecification<Category>(s => s.CategoryID == CategoryID);
        }

        public static BaseSpecification<Category> FindAsyncSpecification(string CategoryID)
        {
            return new BaseSpecification<Category>(s => s.CategoryID == CategoryID);
        }
    }
}
