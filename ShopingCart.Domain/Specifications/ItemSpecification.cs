using ShopingCart.Domain.Core.Specifications;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Domain.Specifications
{
    public static class ItemSpecification
    {
        public static BaseSpecification<Items> FirstOrDefaultItems(string ItemCode)
        {
            return new BaseSpecification<Items>(s => s.ItemCode == ItemCode);
        }

        public static BaseSpecification<Items> FindAsyncItems(string ItemCode)
        {
            return new BaseSpecification<Items>(s => s.ItemCode == ItemCode);
        }
    }
}
