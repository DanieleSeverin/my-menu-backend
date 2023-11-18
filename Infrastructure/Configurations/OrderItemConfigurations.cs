using Domain.Dishes;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(item => item.Id);

        builder.Property(item => item.Id).HasConversion(
            orderItemId => orderItemId.Value,
            value => new OrderItemId(value));

        builder.Property(item => item.DishId).HasConversion(
            dishId => dishId.Value,
            value => new DishId(value));

        builder.Property(item => item.OrderId).HasConversion(
            orderId => orderId.Value,
            value => new OrderId(value));

        builder.HasOne(item => item.Order)
            .WithMany(order => order.Items)
            .HasForeignKey(item => item.OrderId)
            .HasPrincipalKey(order => order.Id);

    }
}
