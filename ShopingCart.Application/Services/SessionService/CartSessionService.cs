using Microsoft.AspNetCore.Http;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Helper;
using ShopingCart.Application.Models.DTOs.CartItemDTOs;

namespace ShopingCart.Application.Services.SessionService
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public void SetCart(CartItemViewModelReq cart)
        {
            _httpContextAccessor.HttpContext.Session.("cart", cart);
        }

       public CartItemViewModelRes GetCart()
        {
            var cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<CartItemViewModelRes>("cart");

            if (cartToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new CartItemViewModelRes());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<CartItemViewModelRes>("cart");
            }

            return cartToCheck;
        }
    }
}
