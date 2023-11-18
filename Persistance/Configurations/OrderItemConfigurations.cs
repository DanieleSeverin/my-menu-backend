using Domain.Businesses;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

internal class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            orderItemId => orderItemId.Value,
            value => new OrderItemId(value));
    }
}
