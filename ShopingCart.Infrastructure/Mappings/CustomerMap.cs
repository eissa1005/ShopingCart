using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Infrastructure
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(p => p.ID)
                .IsRequired()
                .IsUnicode()
                .HasColumnType<int>("Integer");


            builder.Property(p => p.CustomerID)
                 .IsRequired()
                 .IsUnicode()
                 .HasMaxLength(100)
                 .HasColumnType("nvarchar(100)");
                

            builder.Property(p => p.CustomerName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar(255)")
                .IsUnicode();

            builder.Property(p => p.Address1)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");

            builder.Property(p => p.Address2)
               .HasMaxLength(500)
               .HasColumnType("nvarchar(500)");

            builder.Property(p => p.City)
               .HasMaxLength(255)
               .HasColumnType("nvarchar(255)");


            builder.Property(p => p.Country)
               .HasMaxLength(255)
               .HasColumnType("nvarchar(255)");


            builder.Property(p => p.Email)
             .HasMaxLength(255)
             .HasColumnType<string>("nvarchar(35)");

        }
    }
}