using Microsoft.AspNetCore.Identity;
using ShopingCart.Common;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Seed
{
    public static class DefaultRoles
    {
       public static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager)
        {

            if(!roleManager.Roles.Any())
            {
               await roleManager.CreateAsync(new IdentityRole(AppSetting.Roles.Admin.ToString()));
               await roleManager.CreateAsync(new IdentityRole(AppSetting.Roles.SuperAdmin.ToString()));
               await roleManager.CreateAsync(new IdentityRole(AppSetting.Roles.User.ToString()));
               await roleManager.CreateAsync(new IdentityRole(AppSetting.Roles.Basic.ToString()));
            }
        }
    }
}
