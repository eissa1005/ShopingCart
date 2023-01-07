using ShopingCart.Domain.Core.Specifications;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Domain.Specifications
{
    public static class CartItemSpecification
    {
        public static BaseSpecification<CartItem> GetFirstOrDefaultCartItem(string CartID)
        {
            return new BaseSpecification<CartItem>(s => s.CartID == CartID);
        }
        public static BaseSpecification<CartItem> FindAsyncSpecificationCart(string CartID)
        {
            return new BaseSpecification<CartItem>(s => s.CartID == CartID);
        }
    }
}
