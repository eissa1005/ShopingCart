using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Infrastructure
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.ID)
                 .IsRequired()
                 .IsUnicode()
                 .HasColumnType<int>("Integer");


            builder.Property(p => p.CategoryID)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(150)
                 .HasColumnType<string>("nvarchar(150)");

            builder.Property(p => p.CategoryName)
               .IsUnicode()
               .IsRequired()
               .HasMaxLength(255)
               .HasColumnType<string>("nvarchar(255)");


            builder.Property(p => p.Description)
              .HasMaxLength(350)
              .HasColumnType<string>("nvarchar(350)");


        }
    }
   
}