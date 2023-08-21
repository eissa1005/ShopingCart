using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Infrastructure
{
    public class CartItemMap : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {

            builder.Property(p => p.ID)
                 .IsRequired()
                 .IsUnicode()
                 .HasColumnType<int>("Integer");
                

            builder.Property(p => p.CartID)
                .IsRequired()
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(p => p.ItemCode)
                .IsRequired()
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(p => p.Quantity)
              .HasColumnType<int>("Integer")
              .HasDefaultValue(0);


            builder.Property(p => p.UnitPrice)
                .HasColumnType<decimal>("decimal")
                .HasDefaultValue(0);

            builder.Property(p => p.Discount)
               .HasColumnType<decimal>("decimal")
               .HasDefaultValue(0);

            builder.Property(p => p.Amount)
               .HasColumnType<int>("Integer")
               .HasDefaultValue(0);

            builder.Property(p => p.Total)
               .HasColumnType<decimal>("decimal")
               .HasDefaultValue(0);

            builder.Property(p => p.ImagePath)
               .HasColumnType<string>("nvarchar(MAX)")
               .IsRequired(false);


            builder.Property(p => p.UserID)
              .IsRequired()
              .HasMaxLength(150)
              .HasColumnType<string>("nvarchar(450)");

        }
    }

}