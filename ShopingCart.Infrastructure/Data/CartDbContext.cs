using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopingCart.Domain.Entities;
using System.Reflection;

namespace ShopingCart.Infrastructure
{
    public class CartDbContext : IdentityDbContext<Users>
    {
        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Users>().ToTable("Users");

            //  Category and Items
            builder.Entity<Items>()
                .HasOne(s => s.Categorie)
                .WithMany(s => s.Items)
                .HasForeignKey(s => s.CategoryID)
                .HasPrincipalKey(s => s.CategoryID)
                 .HasConstraintName("FK_Cart_CategoryID")
                .IsRequired();


            // CartItem and User
            //modelBuilder.Entity<CartItem>()
            //   .HasOne(s => s.Users)
            //   .WithMany(s => s.CartItems)
            //   .HasForeignKey(s => s.UserID)
            //   .HasPrincipalKey(s=> s.UserID)
            //   .IsRequired();

            // CartItem and Items
            builder.Entity<CartItem>()
                .HasOne(s => s.Items)
                .WithMany(s => s.CartItems)
                .HasForeignKey(s => s.ItemCode)
                .HasPrincipalKey(s => s.ItemCode)
                .HasConstraintName("FK_Cart_ItemsID")
                .IsRequired();

            // CartItem and Customer
            builder.Entity<CartItem>()
                .HasOne(s => s.Customer)
                .WithMany(s => s.CartItems)
                .HasForeignKey(s => s.CustomerID)
                .HasPrincipalKey(s => s.CustomerID)
                .HasConstraintName("PK_CartCustomerID")
                .IsRequired();



            builder.Entity<Users>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");






            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

          

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Users> Users { get; set; }
        //public DbSet<UserClaims> UserClaims { get; set; }
        //public DbSet<RoleClaims> RoleClaims { get; set; }
        //public DbSet<UserRoles> UserRoles { get; set; }
        //public DbSet<Roles> Roles { get; set; }
        //public DbSet<UserLogins> UserLogins { get; set; }
        //public DbSet<UserTokens> UserTokens { get; set; }




    }
}
