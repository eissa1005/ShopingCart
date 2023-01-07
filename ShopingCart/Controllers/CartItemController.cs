using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.CartItemDTOs;
using ShopingCart.Common;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Controllers
{

    public class CartItemController : Controller
    {
        private readonly ICartItemService cartItemService;
        private readonly ILoggerService logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        private readonly ICartSessionService Session;

        public List<CartItemViewModelReq> listCartItem = new List<CartItemViewModelReq>();

        public CartItemController(ICartItemService cartItemService, ILoggerService logger, IMapper mapper, IUnitOfWork uow, ICartSessionService Session)
        {
            this.cartItemService = cartItemService;
            this.logger = logger;
            this.mapper = mapper;
            this.uow = uow;
            this.Session = Session;
        }

        public async Task<JsonResult> Index(string itemID)
        {
            CartItemViewModelReq objCartItem = new CartItemViewModelReq();

            var objItems = await uow.Repository<Items>().FindAsync(itemID);

            if(Session.GetCart() != null)
            {

            }

            if (listCartItem.All(s => s.ItemCode == itemID))
            {
                objCartItem = listCartItem.Single(s => s.ItemCode == itemID);
                objCartItem.Quantity = objCartItem.Quantity + 1;
                objCartItem.Total = objCartItem.Quantity * objCartItem.UnitPrice;
                objCartItem.Amount = objCartItem.Total - objCartItem.Discount;
            }
            else
            {
                objCartItem.ItemCode = itemID;
                objCartItem.CartID = objItems.ItemCode;
                objCartItem.ItemName = objItems.ItemName;
                objCartItem.Quantity = 1;
                objCartItem.UnitPrice = objItems.ItemPrice;
                objCartItem.Discount = objItems.Discount;
                objCartItem.Total = objCartItem.UnitPrice * objCartItem.Quantity;
                objCartItem.Amount = objCartItem.Total - objItems.Discount;
                listCartItem.Add(objCartItem);
            }

            return new JsonResult(new { success = true, data = listCartItem  });
        }
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost(CartItemRoute.AddNew)]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddNew(CartItemViewModelReq req)
        {
            await cartItemService.CreateCartItem(req);
            return new JsonResult(new { data = req });
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPut(CartItemRoute.Edit)]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit(int ID)
        {
            var cartItem = await cartItemService.GetCartItemByIdAsync(ID);
            var reuest = mapper.Map<CartItemViewModelReq>(cartItem);
            if (reuest == null)
            {
                logger.LogError($"Can't Edit ID equal zero {typeof(CategoryController)}");
                return new JsonResult(null);
            }
            await cartItemService.UpdateCartItem(reuest);
            return new JsonResult(new { data = cartItem });
        }

        [HttpDelete(CartItemRoute.Delete)]
        public async Task<JsonResult> Delete(int ID)
        {
            if (ID == 0) return new JsonResult(null);

            var cartItem = await cartItemService.GetCartItemByIdAsync(ID);
            var request = mapper.Map<CartItemViewModelReq>(cartItem);
            if (request == null || request.ID == 0)
            {
                logger.LogError($"Can't Remove ID equal zero {typeof(CategoryController)}");
                return new JsonResult(null);
            }
            await cartItemService.DeleteCartItem(request);
            return new JsonResult(new { data = cartItem });
        }
    }
}
