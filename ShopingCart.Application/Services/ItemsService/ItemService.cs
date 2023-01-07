using AutoMapper;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.CategoryDTOs;
using ShopingCart.Application.Models.DTOs.ItemsDTOs;
using ShopingCart.Domain.Entities;
using ShopingCart.Domain.Specifications;

namespace ShopingCart.Application.Services.ItemsService
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork uow;
        private readonly ILoggerService logService;
        private readonly IMapper mapper;

        public ItemService(IUnitOfWork uow, ILoggerService logService, IMapper mapper)
        {
            this.uow = uow;
            this.logService = logService;
            this.mapper = mapper;
        }
        public async Task<ItemsViewModelRes> FindItemsAsync(string itemCode)
        {
            var item = await uow.Repository<Items>().FindAsync(itemCode);
            var itemDto = mapper.Map<ItemsDTOs>(item);
            return new ItemsViewModelRes() { Data = itemDto };
        }
        public async Task<ItemsViewModelRes> GetItemsById(int ID)
        {
            var item = await uow.Repository<Items>().GetById(ID);
            var itemDto = mapper.Map<ItemsDTOs>(item);
            return new ItemsViewModelRes() { Data = itemDto };
        }
        public async Task<ItemsViewModelRes> FirstOrDefaultItems(string itemCode)
        {
            var itemSpecification = ItemSpecification.FirstOrDefaultItems(itemCode);
            var item = await uow.Repository<Items>().FirstOrDefaultAsync(itemSpecification);
            var itemDto = mapper.Map<ItemsDTOs>(item);
            return new ItemsViewModelRes() { Data = itemDto };
        }
        public async Task<IReadOnlyCollection<ItemsViewModelRes>> GetAllItems()
        {
            var lstitems = await uow.Repository<Items>().AllListAsync();
            var lstItemsView = new List<ItemsViewModelRes>();

            foreach (var objData in lstitems)
            {
                lstItemsView.Add(new ItemsViewModelRes() { Data = ItemsDTOs.Create(objData) });
            }

            return lstItemsView;
        }
        public async Task<int> AddItems(ItemsViewModelReq request)
        {
            if (request == null)
            {
                logService.LogError($" Can't Add Empty Items {typeof(ItemService)}");
                return await Task.FromResult(0);
            }

            var items = mapper.Map<Items>(request);
            await uow.Repository<Items>().AddAsync(items);
            return await uow.SaveChangesAsync();
        }
        public async Task<int> UpdateItems(ItemsViewModelReq request)
        {
            if (request == null)
            {
                logService.LogError($" Can't Update Empty Items {typeof(ItemService)}");
                return await Task.FromResult(0);
            }

            var items = mapper.Map<Items>(request);
            uow.Repository<Items>().Update(items);
            return await uow.SaveChangesAsync();
        }
        public async Task<int> DeleteItems(ItemsViewModelReq request)
        {
            if (request == null)
            {
                logService.LogError($" Can't Delete Empty Items {typeof(ItemService)}");
                return await Task.FromResult(0);
            }

            var items = mapper.Map<Items>(request);
            uow.Repository<Items>().Delete(items);
            return await uow.SaveChangesAsync();
        }

    }
}
