using AutoMapper;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.CategoryDTOs;
using ShopingCart.Domain.Entities;
using ShopingCart.Domain.Specifications;

namespace ShopingCart.Application.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork uow;
        private readonly ILoggerService loggerService;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork uow, ILoggerService logService, IMapper mapper)
        {
            this.uow = uow;
            this.loggerService = logService;
            this.mapper = mapper;
        }
        public async Task<CategoryViewModelRes> GetByIdAsync(int id)
        {
            var category = await uow.Repository<Category>().GetById(id);
            var CategoetDto = mapper.Map<CategoryDTOs>(category);
            return new CategoryViewModelRes() { Data = CategoetDto };
        }
        public async Task<CategoryViewModelRes> FindAsync(string id)
        {
            var category = await uow.Repository<Category>().FindAsync(id);
            var CategoetDto = mapper.Map<CategoryDTOs>(category);
            return new CategoryViewModelRes() { Data = CategoetDto };
        }
        public async Task<CategoryViewModelRes> FirstOrDefaultAsync()
        {
            var category = await uow.Repository<Category>().FirstOrDefaultAsync();
            var categoryDto = mapper.Map<CategoryDTOs>(category);
            return new CategoryViewModelRes() { Data = categoryDto };
        }
        public async Task<CategoryViewModelRes> FirstOrDefaultAsync(string CategoryID)
        {
            var categorySpecification = CategorySpecification.GetFirstOrDefaultCategory(CategoryID);

            var category = await uow.Repository<Category>().FirstOrDefaultAsyncSpec(categorySpecification);

            var categoryDto = mapper.Map<CategoryDTOs>(category);

            return new CategoryViewModelRes() { Data = categoryDto };

        }
        public async Task<IReadOnlyCollection<CategoryViewModelRes>> GetAllCategoryAsync()
        {
            var lst = await uow.Repository<Category>().AllListAsync();
            var lstDTOs = new List<CategoryDTOs>();
            var lstCategoryView = new List<CategoryViewModelRes>();

            foreach (var category in lst)
            {
                lstDTOs.Add(CategoryDTOs.Create(category));

                lstCategoryView.Add(new CategoryViewModelRes() { Data = CategoryDTOs.Create(category) });
            }

            return lstCategoryView;

        }

        public async Task<int> CreateCategory(CategoryViewModelReq request)
        {
            var category = mapper.Map<Category>(request);
            if (category == null)
            {
                loggerService.LogError("Category is Empty");
                return await Task.FromResult(0);
            }

            await uow.Repository<Category>().AddAsync(category);
            return await uow.SaveChangesAsync();
        }

        public async Task<int> UpdateCategory(CategoryViewModelReq request)
        {
            if (request == null || request.ID == 0)
            {
                loggerService.LogError($"Can't Update Category {typeof(CategoryService)}");
                return await Task.FromResult(0);
            }

            var category = mapper.Map<Category>(request);
            uow.Repository<Category>().Update(category);
            return await uow.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(CategoryViewModelReq request)
        {
            if (request == null || request.ID == 0)
            {
                loggerService.LogError($"Can't Remove Category {typeof(CategoryService)}");
                return await Task.FromResult(0);
            }

            var category = await uow.Repository<Category>().GetById(request.ID);

            if (category == null || category.ID == 0)
            {
                loggerService.LogError($"Can't Remove Category {typeof(CategoryService)}");
                return await Task.FromResult(0);
            }

            uow.Repository<Category>().Delete(category);
            return await uow.SaveChangesAsync();
        }



    }
}
