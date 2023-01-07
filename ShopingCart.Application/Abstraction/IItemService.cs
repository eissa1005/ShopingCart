using ShopingCart.Application.Models.DTOs.ItemsDTOs;

namespace ShopingCart.Application.Abstraction
{
    public interface IItemService
    {
        Task<ItemsViewModelRes> GetItemsById(int ID);
        Task<ItemsViewModelRes> FindItemsAsync(string itemCode);
        Task<IReadOnlyCollection<ItemsViewModelRes>> GetAllItems();
        Task<ItemsViewModelRes> FirstOrDefaultItems(string itemCode);
        Task<int> AddItems(ItemsViewModelReq request);
        Task<int> UpdateItems(ItemsViewModelReq request);
        Task<int> DeleteItems(ItemsViewModelReq request);
    }
}
