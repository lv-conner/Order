using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderDb.EntityMaps
{
    public class OrderMap : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(p => p.OrderId);
            builder.Property(p => p.OrderId).HasMaxLength(50);
            builder.Property(p => p.ProductName).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(p => p.Remark).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(p => p.Quantity).IsRequired();

        }
    }
}
