using Microsoft.EntityFrameworkCore;
using ShopingCart.Domain.Entities;
using System.Reflection;

namespace ShopingCart.Infrastructure
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //  Category and Items
            modelBuilder.Entity<Items>()
                .HasOne(s => s.Categorie)
                .WithMany(s => s.Items)
                .HasForeignKey(s => s.CategoryID)
                .HasPrincipalKey(s => s.CategoryID)
                 .HasConstraintName("FK_Cart_CategoryID")
                .IsRequired();


            // CartItem and User
            modelBuilder.Entity<CartItem>()
               .HasOne(s => s.Users)
               .WithMany(s => s.CartItems)
               .HasForeignKey(s => s.ID)
               .IsRequired();

            // CartItem and Items
            modelBuilder.Entity<CartItem>()
                .HasOne(s => s.Items)
                .WithMany(s => s.CartItems)
                .HasForeignKey(s => s.ItemCode)
                .HasPrincipalKey(s => s.ItemCode)
                .HasConstraintName("FK_Cart_ItemsID")
                .IsRequired();

            // CartItem and Customer
            modelBuilder.Entity<CartItem>()
                .HasOne(s => s.Customer)
                .WithMany(s => s.CartItems)
                .HasForeignKey(s => s.CustomerID)
                .HasPrincipalKey(s => s.CustomerID)
                .HasConstraintName("PK_CartCustomerID")
                .IsRequired();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Customer> Customer { get; set; }



    }
}
