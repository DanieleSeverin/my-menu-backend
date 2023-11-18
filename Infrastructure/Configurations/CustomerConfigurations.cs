using Domain.Businesses;
using Domain.Customers;
using Domain.Orders;
using Domain.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));

        builder.Property(customer => customer.BusinessId).HasConversion(
            businessId => businessId.Value,
            value => new BusinessId(value));

        builder.Property(customer => customer.TableId).HasConversion(
            businessId => businessId.Value,
            value => new TableId(value));

        builder.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .HasPrincipalKey(c => c.Id);

    }
}
