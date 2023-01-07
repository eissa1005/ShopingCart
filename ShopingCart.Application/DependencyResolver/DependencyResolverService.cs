using Microsoft.Extensions.DependencyInjection;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Services.CartItemService;
using ShopingCart.Application.Services.CategoryService;
using ShopingCart.Application.Services.CustomerService;
using ShopingCart.Application.Services.ItemsService;
using ShopingCart.Application.Services.ServiceUsers;
using ShopingCart.Application.Services.SessionService;
using System.Reflection;

namespace ShopingCart.Application
{
    public static class DependencyResolverService
    {
        public static IServiceCollection ApplicationRegister(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICartItemService,CartItemService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICartSessionService, CartSessionService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
