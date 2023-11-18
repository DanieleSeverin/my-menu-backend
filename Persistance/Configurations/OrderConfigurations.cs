using Domain.Businesses;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

internal class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            orderId => orderId.Value,
            value => new OrderId(value));
    }
}
