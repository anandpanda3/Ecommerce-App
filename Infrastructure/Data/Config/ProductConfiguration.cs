using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(380);
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(p => p.ProductBrand).WithMany()
                .HasForeignKey(x => x.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany()
                .HasForeignKey(x => x.ProductTypeId);
        }
    }
}
