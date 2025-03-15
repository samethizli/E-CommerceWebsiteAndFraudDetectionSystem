﻿using Ekitap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekitap.Data.Configurations
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Phone).HasColumnType("varchar(50)").HasMaxLength(20);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CreateDate)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
