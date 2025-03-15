using Ekitap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekitap.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.ProductCode).HasMaxLength(50);
            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(30);

            // Price alanı için hassasiyet (precision) tanımlaması
            builder.Property(x => x.Price).HasPrecision(18, 2);
            builder.Property(x => x.CreateDate)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
