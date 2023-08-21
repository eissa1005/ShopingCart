using Microsoft.AspNetCore.Identity;
using NLog.Web;
using ShopingCart.Application;
using ShopingCart.Application.Core.Services;
using ShopingCart.Domain.Entities;
using ShopingCart.Infrastructure;
using ShopingCart.Infrastructure.Services;
using ShopingCart.Seed;

var builder = WebApplication.CreateBuilder(args);
var Services = builder.Services;

var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();



//ShopingCart.Application.DependencyResolver.DependencyResolverService.ApplicationRegister(builder.Services);
//ShopingCart.Infrastructure.DependencyResolver.DependencyResolverService.AddInfrastructureService(builder.Services, appSettings);

// Add services to the container.
Services.AddControllersWithViews();
Services.AddInfrastructureService(appSettings);
Services.ApplicationRegister();
Services.AddIdentity<Users, IdentityRole>()
.AddEntityFrameworkStores<CartDbContext>()
.AddDefaultTokenProviders();

Services.AddHttpContextAccessor();

builder.Host.UseNLog();

var app = builder.Build();
using var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;
var logger = provider.GetRequiredService<ILoggerService>();

try
{
    var userManager = provider.GetRequiredService<UserManager<Users>>();
    var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

    await DefaultRoles.SeedRoleAsync(roleManager);
    await DefaultUser.SeedBasicUserAsync(userManager);
    await DefaultUser.SeedSuperAdminUserAsync(userManager, roleManager);

}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while seeding data");

}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
