using Domain.Businesses;
using Domain.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

internal class TableConfigurations : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            tableId => tableId.Value,
            value => new TableId(value));
    }
}
