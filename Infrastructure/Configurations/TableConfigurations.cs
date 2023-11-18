using Domain.Businesses;
using Domain.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class TableConfigurations : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(table => table.Id);

        builder.Property(table => table.Id).HasConversion(
            tableId => tableId.Value,
        value => new TableId(value));

        builder.Property(table => table.BusinessId).HasConversion(
            businessId => businessId.Value,
            value => new BusinessId(value));

        builder.HasMany(table => table.Customers)
            .WithOne(customer => customer.Table)
            .HasForeignKey(t => t.TableId)
            .HasPrincipalKey(b => b.Id);
    }
}
