using Ekitap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekitap.Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Phone).HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(x => x.Password).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);



            // Veritabanına sabit değerle veri ekleme
            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Admin",
                    Password = "123456",
                    Surname = "User",

                },
                  new AppUser
                  {
                      Id = 2,
                      UserName = "Samet",
                      Email = "samet@gmail.com",
                      IsActive = true,
                      IsAdmin = true,
                      Name = "samet",
                      Password = "1234546",
                      Surname = "User2",

                  }


            );
        }
    }
}
