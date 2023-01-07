using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Infrastructure
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.ID)
                 .IsRequired()
                 .IsUnicode()
                 .HasColumnType<int>("Integer");

            builder.Property(p => p.UserID)
                .IsUnicode()
                .IsRequired()
                .HasColumnType<string>("nvarchar(150)")
                .HasMaxLength(150);


            builder.Property(p => p.UserName)
               .IsUnicode()
               .IsRequired()
               .HasColumnType<string>("nvarchar(300)")
               .HasMaxLength(300);

            builder.Property(p => p.Address)
               .HasColumnType<string>("nvarchar(300)")
               .HasMaxLength(300);

            builder.Property(p => p.City)
             .HasColumnType<string>("nvarchar(200)")
             .HasMaxLength(200);

            builder.Property(p => p.Country)
            .HasColumnType<string>("nvarchar(200)")
            .HasMaxLength(200);

            builder.Property(p => p.FirstName)
            .HasColumnType<string>("nvarchar(150)")
            .HasMaxLength(150);

            builder.Property(p => p.LastName)
           .HasColumnType<string>("nvarchar(150)")
           .HasMaxLength(150);

            builder.Property(p => p.UserName)
            .IsRequired()
            .IsUnicode()
            .HasColumnType<string>("nvarchar(150)")
            .HasMaxLength(150);


            builder.Property(p => p.Balance)
           .HasColumnType<decimal>("decimal")
           .HasMaxLength(150).HasDefaultValue(0);


            builder.Property(p => p.Status)
                .HasConversion<int>()
                .HasDefaultValueSql("1");

            builder.Property(p => p.Phone)
            .HasMaxLength(25)
            .HasColumnType<string>("nvarchar(25)")
            .HasMaxLength(25);


            builder.Property(p => p.Email)
            .HasColumnType<string>("nvarchar(350)");

            builder.Property(p => p.Password)
                .HasColumnType<string>("nvarchar(350)")
                .HasMaxLength(350);




        }

    }
}
