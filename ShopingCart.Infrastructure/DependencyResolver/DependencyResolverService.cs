using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopingCart.Application.Core.Repositories;
using ShopingCart.Application.Core.Services;
using ShopingCart.Infrastructure.Services;


namespace ShopingCart.Infrastructure
{
    public static class DependencyResolverService
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CartDbContext>(options =>

             options.UseSqlServer("name=ConnectionStrings:CartDbConnection", k => k.MigrationsAssembly("ShopingCart.DbMigrations")));
            
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoggerService, LoggerService>();


            return services;

        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<CartDbContext>>();
            using (var db = new CartDbContext(options))
            {
                db.Database.Migrate();
            }

        }
    }
}