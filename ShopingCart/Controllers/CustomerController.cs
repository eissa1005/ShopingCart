using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.CustomerDTOs;
using ShopingCart.Common;


namespace ShopingCart.Controllers
{

    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ILoggerService logger;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService, ILoggerService logger, IMapper mapper)
        {
            this.customerService = customerService;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var lst = await customerService.GetAllCustomers();
            return View(lst);
        }


        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost(CustomerRoute.AddNew)]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddNew(CustomerViewModelReq req)
        {
            if(req == null || string.IsNullOrWhiteSpace(req.CustomerID))
            {
                logger.LogError($"Customer is Null {typeof(CustomerController)}");
                return new JsonResult(null);
            }
            await customerService.AddCustomer(req);
            return new JsonResult(new { data = req });
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPut(CustomerRoute.Edit)]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit(int ID)
        {
            var category = await customerService.GetCustomerById(ID);
            var reuest = mapper.Map<CustomerViewModelReq>(category);
            if (reuest == null)
            {
                logger.LogError($"Can't Edit ID equal zero {typeof(CustomerController)}");
                return new JsonResult(null);
            }
            await customerService.UpdateCustomer(reuest);
            return new JsonResult(new { data = category });
        }

        [HttpDelete(CustomerRoute.Delete)]
        public async Task<JsonResult> Delete(int ID)
        {
            if (ID == 0) return new JsonResult(null);

            var customer = await customerService.GetCustomerById(ID);
            var request = mapper.Map<CustomerViewModelReq>(customer);
            if (request == null || request.ID == 0)
            {
                logger.LogError($"Can't Remove ID equal zero  {typeof(CustomerController)}");
                return new JsonResult(null);
            }
            await customerService.DeleteCustomer(request);
            return new JsonResult(new { data = customer });
        }
    }
}
