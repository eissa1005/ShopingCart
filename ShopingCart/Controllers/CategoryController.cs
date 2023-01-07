using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Services;
using ShopingCart.Application.Models.DTOs.CategoryDTOs;
using ShopingCart.Common;
using ShopingCart.Domain.Entities;


namespace ShopingCart.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ILoggerService logger;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService categoryService, ILoggerService logger, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var lst = await categoryService.GetAllCategoryAsync();
            return View(lst);
        }

       
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost(CategoryRoute.AddNew)]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddNew(CategoryViewModelReq req)
        {
            await categoryService.CreateCategory(req);
            return new JsonResult(new { data = req });
        }

        public async Task<ActionResult> Edit(int CatID)
        {
            var lstCategory = await categoryService.GetByIdAsync(CatID);
            return View(lstCategory);
        }

        //[HttpPut(CategoryRoute.Edit)]
        //[ValidateAntiForgeryToken]
        [HttpPost("Edit/{id}")]
        public async Task<JsonResult> Edit(CategoryViewModelReq req)
        {
            var category = await categoryService.FirstOrDefaultAsync(req.CategoryID);
            var reuest = mapper.Map<CategoryViewModelReq>(category);
            if (reuest == null)
            {
                logger.LogError($"Can't Edit ID equal zero {typeof(CategoryController)}");
                return new JsonResult(null);
            }
            await categoryService.UpdateCategory(reuest);
            return new JsonResult(new { data = category });
        }

        [HttpDelete(CategoryRoute.Delete)]
        public async Task<JsonResult> Delete(int ID)
        {
            if(ID == 0) return new JsonResult(null);

            var category = await categoryService.GetByIdAsync(ID);
            var request =  mapper.Map<CategoryViewModelReq>(category);
            if(request == null || request.ID == 0)
            {
                logger.LogError($"Can't Remove ID equal zero {typeof(CategoryController)}");
                return new JsonResult(null);
            }
            await categoryService.DeleteCategory(request);
            return new JsonResult(new { data = category });
        }
    }
}
