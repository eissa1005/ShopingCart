using ShopingCart.Application.Models.DTOs.CategoryDTOs;

namespace ShopingCart.Application.Abstraction
{
    public interface ICategoryService
    {
        Task<CategoryViewModelRes> GetByIdAsync(int id);
        Task<CategoryViewModelRes> FindAsync(string id);
        Task<IReadOnlyCollection<CategoryViewModelRes>> GetAllCategoryAsync();
        Task<CategoryViewModelRes> FirstOrDefaultAsync(string CategoryID);
        Task<int> CreateCategory(CategoryViewModelReq request);
        Task<int> UpdateCategory(CategoryViewModelReq request);
        Task<int> DeleteCategory(CategoryViewModelReq request);
        //Task<int> GetCountCategoryAsync(ISpecification<Category> specification);

    }
}
