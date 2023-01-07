using ShopingCart.Application.Models.DTOs.CartItemDTOs;

namespace ShopingCart.Application.Abstraction
{
    public interface ICartSessionService
    {
        CartItemViewModelRes GetCart();
        void SetCart(CartItemViewModelReq cart);
    }
}
