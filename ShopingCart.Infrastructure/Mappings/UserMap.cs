using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopingCart.Domain.Entities;

namespace ShopingCart.Infrastructure
{
    public class UserMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {

            //builder.Property(p => p.UserID)
            //    .IsUnicode()
            //    .IsRequired()
            //    .HasColumnType<string>("nvarchar(450)")
            //    .HasMaxLength(450);


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


            builder.Property(p => p.Status)
                .HasConversion<int>()
                .HasDefaultValueSql("1");

            builder.Property(p => p.Phone)
            .HasMaxLength(25)
            .HasColumnType<string>("nvarchar(25)")
            .HasMaxLength(25);


        }

    }
}
