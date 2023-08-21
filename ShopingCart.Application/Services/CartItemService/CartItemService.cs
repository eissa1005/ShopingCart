using AutoMapper;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.CartItemDTOs;
using ShopingCart.Domain.Entities;
using ShopingCart.Domain.Specifications;

namespace ShopingCart.Application.Services.CartItemService
{
    public class CartItemService : ICartItemService
    {

        private readonly IUnitOfWork uow;
        private readonly ILoggerService loggerService;
        private readonly IMapper mapper;

        public CartItemService(IUnitOfWork uow, ILoggerService loggerService, IMapper mapper)
        {
            this.uow = uow;
            this.loggerService = loggerService;
            this.mapper = mapper;
        }
        public async Task<CartItemViewModelRes> GetCartItemByIdAsync(int id)
        {
            var cartItems = await uow.Repository<CartItem>().GetById(id);
            return mapper.Map<CartItemViewModelRes>(cartItems);
        }
        public async Task<CartItemViewModelRes> FirstOrDefaultAsync(string CartID)
        {
            var cartitemspec = CartItemSpecification.GetFirstOrDefaultCartItem(CartID);

            var cartItems = await uow.Repository<CartItem>().FirstOrDefaultAsyncSpec(cartitemspec);

            return mapper.Map<CartItemViewModelRes>(cartItems);
        }

        public async Task<IReadOnlyCollection<CartItemViewModelRes>> GetAllCartItemAsync()
        {
            var lstCartItems = await uow.Repository<CartItem>().AllListAsync();
            var lstCartItem = new List<CartItemViewModelRes>();
            foreach (var item in lstCartItems)
            {
                lstCartItem.Add(new CartItemViewModelRes() { Data = CartItemDTOs.Create(item) });
            }
            return lstCartItem;
        }
        public async Task<int> CreateCartItem(CartItemViewModelReq request)
        {
            if (request == null)
            {
                loggerService.LogError($"Can't Add Empty CartItem {typeof(CartItemService)}");
                return await Task.FromResult(0);
            }

            var cartItems = mapper.Map<CartItem>(request);
            await uow.Repository<CartItem>().AddAsync(cartItems);
            return await uow.SaveChangesAsync();
        }

        public async Task<int> UpdateCartItem(CartItemViewModelReq request)
        {
            if (request == null)
            {
                loggerService.LogError($"Can't Update Empty CartItem {typeof(CartItemService)}");
                return await Task.FromResult(0);
            }

            var cartItems = mapper.Map<CartItem>(request);
            uow.Repository<CartItem>().Update(cartItems);
            return await uow.SaveChangesAsync();
        }
        public async Task<int> DeleteCartItem(CartItemViewModelReq request)
        {
            if (request == null)
            {
                loggerService.LogError($"Can't Update Empty CartItem {typeof(CartItemService)}");
                return await Task.FromResult(0);
            }
            var cartItems = mapper.Map<CartItem>(request);
            uow.Repository<CartItem>().Delete(cartItems);
            return await uow.SaveChangesAsync();
        }

    }
}
