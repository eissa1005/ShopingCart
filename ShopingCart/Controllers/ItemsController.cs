using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.CartItemDTOs;
using ShopingCart.Application.Models.DTOs.ItemsDTOs;
using ShopingCart.Common;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Controllers
{

    public class ItemsController : Controller
    {
        private readonly IItemService itemService;
        private readonly IUnitOfWork uow;
        private readonly ILoggerService logger;
        private readonly IMapper mapper;
        private readonly ISessionService Session;
        public List<CartItemViewModelReq> listCartItem { get; set; } = new();

        public ItemsController(IItemService iitemService, ILoggerService logger, IMapper mapper , IUnitOfWork uow, ISessionService Session)
        {
            this.itemService = iitemService;
            this.logger = logger;
            this.mapper = mapper;
            this.uow = uow;
            this.Session= Session;
        }

        public async Task<ActionResult> Index()
        {
            var lst = await itemService.GetAllItems();
            return View(lst);
        }

        [HttpPost]
        public async Task<JsonResult> Index(int itemId)
        {
            CartItemViewModelReq objCartItem = new CartItemViewModelReq();

            var objItems = await uow.Repository<Items>().GetById(itemId);
            var sData = Session.Get("Cart");
           
            if (sData != null)
            {
                listCartItem = Session.GetObjects<CartItemViewModelReq>("Cart").ToList();

            }

            if (listCartItem.All(s => s.ID == itemId))
            {
                objCartItem = listCartItem.Single(s => s.ID == itemId);
                objCartItem.Quantity = objCartItem.Quantity + 1;
                objCartItem.Total = objCartItem.Quantity * objCartItem.UnitPrice;
                objCartItem.Amount = objCartItem.Total - objCartItem.Discount;
            }
            else
            {
                objCartItem.ID = itemId;
                objCartItem.ItemCode = objItems.ItemCode;
                objCartItem.CartID = objItems.ItemCode;
                objCartItem.ItemName = objItems.ItemName;
                objCartItem.Quantity = objItems.Quantity;
                objCartItem.UnitPrice = objItems.ItemPrice;
                objCartItem.Discount = objItems.Discount;
                objCartItem.Total = objCartItem.UnitPrice * objCartItem.Quantity;
                objCartItem.Amount = objCartItem.Total - objItems.Discount;
                listCartItem.Add(objCartItem);
            }

            Session.SetObject<CartItemViewModelReq>("Cart", objCartItem);
            Session.SetInt32("counter", listCartItem.Count);
            return new JsonResult(new { success = true, counter = listCartItem.Count, data = listCartItem });
        }

        public async Task<ActionResult> AddNew()
        {
            var allCategory = await uow.Repository<Category>().AllListAsync();
            ViewBag.SelectCategory = new SelectList(allCategory, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost(ItemsRoute.AddNew)]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddNew(ItemsViewModelReq req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.ItemCode))
            {
                logger.LogError($"Items is Null {typeof(ItemsController)}");
                return new JsonResult(null);
            }
            await itemService.AddItems(req);
            return new JsonResult(new { data = req });
        }

        [HttpPost]
        public async Task<JsonResult> Search(string productName)
        {
            var products = (from objdata in await itemService.GetAllItems()
                            where objdata.Data.ItemName.Contains(productName)
                            select objdata).ToList();
            return Json(products.ToList().Take(10));
        }
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPut(ItemsRoute.Edit)]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit(int ID)
        {
            var item = await itemService.GetItemsById(ID);
            var reuest = mapper.Map<ItemsViewModelReq>(item);
            if (reuest == null)
            {
                logger.LogError($"Can't Edit ID equal zero {typeof(CustomerController)}");
                return new JsonResult(null);
            }
            await itemService.UpdateItems(reuest);
            return new JsonResult(new { data = item });
        }

        [HttpDelete(ItemsRoute.Delete)]
        public async Task<JsonResult> Delete(int ID)
        {
            if (ID == 0) return new JsonResult(null);

            var item = await itemService.GetItemsById(ID);
            var request = mapper.Map<ItemsViewModelReq>(item);
            if (request == null || request.ID == 0)
            {
                logger.LogError($"Can't Remove ID equal zero  {typeof(CustomerController)}");
                return new JsonResult(null);
            }
            await itemService.DeleteItems(request);
            return new JsonResult(new { data = item });
        }


    }
}
