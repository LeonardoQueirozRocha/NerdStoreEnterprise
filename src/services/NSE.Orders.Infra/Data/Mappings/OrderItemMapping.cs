﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Orders.Domain.Orders;

namespace NSE.Orders.Infra.Data.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProductName)
                   .IsRequired()
                   .HasColumnType("varchar(250)");

            builder.HasOne(c => c.Order)
                   .WithMany(c => c.OrderItems);

            builder.ToTable("OrderItems");
        }
    }
}
