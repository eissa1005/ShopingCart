using ShopingCart.Application.Models.DTOs.CartItemDTOs;

namespace ShopingCart.Application.Abstraction
{
    public interface ICartItemService
    {
        Task<CartItemViewModelRes> GetCartItemByIdAsync(int id);
        Task<IReadOnlyCollection<CartItemViewModelRes>> GetAllCartItemAsync();
        Task<CartItemViewModelRes> FirstOrDefaultAsync(string CategoryID);
        Task<int> CreateCartItem(CartItemViewModelReq request);
        Task<int> UpdateCartItem(CartItemViewModelReq request);
        Task<int> DeleteCartItem(CartItemViewModelReq request);
    }
}
