using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Infrastructure
{
    public class ItemsMap : IEntityTypeConfiguration<Items>
    {
        public void Configure(EntityTypeBuilder<Items> builder)
        {

            builder.Property(p => p.ID)
               .IsRequired()
               .IsUnicode()
               .HasColumnType<int>("Integer");


            builder.Property(p => p.ItemCode)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            builder.Property(p => p.ItemName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(255)
                .HasColumnType("nvarchar(255)");

            builder.Property(p => p.Quantity)
              .HasMaxLength(150)
              .HasColumnType<decimal>("decimal")
              .HasDefaultValue(0);

            builder.Property(p => p.ItemPrice)
                .HasMaxLength(150)
                .HasColumnType<decimal>("decimal")
                .HasDefaultValue(0);

            builder.Property(p => p.Total)
                .HasMaxLength(150)
                .HasColumnType<decimal>("decimal")
                .HasDefaultValue(0);

            builder.Property(p => p.Description)
               .HasMaxLength(350)
               .HasColumnType("nvarchar(350")
               .HasColumnType<string>("nvarchar(350)");


            builder.Property(p => p.CategoryID)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType<string>("nvarchar(150)");


            builder.Property(p => p.ImagePath)
           .HasColumnType<string>("nvarchar(MAX)");

        }
    }
}