using Domain.Businesses;
using Domain.Customers;
using Domain.Orders;
using Domain.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Persistance.Configurations;

internal class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));

        builder.Property(c => c.BusinessId).HasConversion(
            businessId => businessId.Value,
            value => new BusinessId(value));

        builder.Property(c => c.TableId).HasConversion(
            businessId => businessId.Value,
            value => new TableId(value));

        // Map OrdersSent navigation property
        builder.HasMany(c => c.OrdersSent)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .HasPrincipalKey(c => c.Id);

        builder.HasQueryFilter(c => c.OrdersSent.Any(o => o.Sent)); // Global Query Filter

        // Navigation property for CurrentOrder
        builder.HasOne(c => c.CurrentOrder)
            .WithOne()
            .HasForeignKey<Customer>(c => c.CurrentOrder.Id)
            .HasPrincipalKey<Order>(o => o.Id)
            .OnDelete(DeleteBehavior.SetNull); // Set to null if CurrentOrder is deleted

    }
}
