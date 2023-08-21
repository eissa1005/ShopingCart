using Microsoft.AspNetCore.Identity;
using ShopingCart.Common;
using ShopingCart.Domain.Entities;
using System.Security.Claims;

namespace ShopingCart.Initialization
{
    public static class DefaultUser
    {
        public static async Task SeedUser(UserManager<Users> userManager)
        {
            var defaultUser = new Users
            {
                FirstName = "User777",
                Email = "user@gmail.com",
                UserName = "user777",
                UserID = "777",
                EmailConfirmed = false,
            };

            if (await userManager.FindByEmailAsync(defaultUser.Email) != null)
                throw new Exception("Email is already exists");

            if (await userManager.FindByNameAsync(defaultUser.UserName) != null)
                throw new Exception("Username is already exists");

            await userManager.CreateAsync(defaultUser, "P@ssword999");
            await userManager.AddToRoleAsync(defaultUser, AppSetting.Roles.User.ToString());

        }

        public static async Task SeedAdmin(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new Users
            {
                FirstName = "useradmin",
                Email = "admin@gmail.com",
                UserName = "admin",
                UserID = "999",
                EmailConfirmed = false,
            };

            if (await userManager.FindByEmailAsync(defaultUser.Email) != null)
                throw new Exception("Email is already exists");

            if (await userManager.FindByNameAsync(defaultUser.UserName) != null)
                throw new Exception("Username is already exists");

            await userManager.CreateAsync(defaultUser, "P@ssword999");
            await userManager.AddToRoleAsync(defaultUser, AppSetting.Roles.Admin.ToString());
            await roleManager.UserClaimsAsync();
        }

        private static async Task UserClaimsAsync(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(AppSetting.Roles.Admin.ToString());
            await roleManager.AddPermission(adminRole, AppSetting.Product.ToString());
        }
        private static async Task AddPermission(this RoleManager<IdentityRole> roleManager, IdentityRole role, string modules)
        {
            var allRoles = await roleManager.GetClaimsAsync(role);
            var allPermission = AppSetting.GeneratePermissionsList(AppSetting.Product);
            foreach (var permission in allPermission)
            {
                if (!allRoles.Any(s => s.Type == AppSetting.Premission && s.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim(AppSetting.Premission, permission));
                }
            }
        }

    }
}
