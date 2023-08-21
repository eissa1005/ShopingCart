using Microsoft.AspNetCore.Identity;
using static ShopingCart.Common.AppSetting;

namespace ShopingCart.Initialization
{
    public static class DefaultRoles
    {
        public static async Task InitRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            }
        }
    }
}
