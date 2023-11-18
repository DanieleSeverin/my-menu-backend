using Domain.Customers;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder.Property(order => order.Id).HasConversion(
            orderId => orderId.Value,
            value => new OrderId(value));

        builder.Property(order => order.CustomerId).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));

        builder.HasMany(order => order.Items)
            .WithOne()
            .HasForeignKey(item => item.OrderId)
            .HasPrincipalKey(order => order.Id);
    }
}
