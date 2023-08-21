using Microsoft.AspNetCore.Identity;
using ShopingCart.Common;
using ShopingCart.Domain.Entities;
using System.Security.Claims;
using static ShopingCart.Common.AppSetting;

namespace ShopingCart.Seed
{
    public static class DefaultUser
    {
        public static async Task SeedBasicUserAsync(UserManager<Users> userManager)
        {
            var defaultUser = new Users
            {
                UserName = "basicuser@domain.com",
                Email = "basicuser@domain.com",
                EmailConfirmed = true,
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssword123");
                await userManager.AddToRoleAsync(defaultUser, AppSetting.Roles.Basic.ToString());
            }
        }

        public static async Task SeedSuperAdminUserAsync(UserManager<Users> userManager, RoleManager<IdentityRole> roleManger)
        {

            var Defaultuser = new Users
            {
                UserName = "superadmin@domain.com",
                Email = "superadmin@domain.com",
                EmailConfirmed = true,
            };

            var user = await userManager.FindByEmailAsync(Defaultuser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(Defaultuser, "P@ssword999");
                await userManager.AddToRolesAsync(Defaultuser, new List<string> { Roles.Admin.ToString(), Roles.SuperAdmin.ToString(), Roles.Basic.ToString() });
            }

            //TODO: Create Claims 
            await roleManger.SeedSuperAdminUserAsync();
        }
        private static async Task SeedSuperAdminUserAsync(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            await roleManager.AddPermissionClaims(adminRole, AppSetting.Product);
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager , IdentityRole role , string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = AppSetting.GeneratePermissionsList(module);

            foreach (var permission in allPermissions)
            {
                if(!allClaims.Any(s=> s.Type == AppSetting.Premission && s.Value == permission))
                {
                    await roleManager.AddClaimAsync(role,new Claim(AppSetting.Premission, permission));
                }
            }

        }
    }
}
