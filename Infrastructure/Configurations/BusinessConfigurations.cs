using Domain.Businesses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class BusinessConfigurations : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            businessId => businessId.Value,
            value => new BusinessId(value));

        builder.HasMany(b => b.Tables)
            .WithOne(t => t.Business)
            .HasForeignKey(t => t.BusinessId)
            .HasPrincipalKey(b => b.Id);

        builder.HasMany(b => b.Menus)
            .WithOne(m => m.Business)
            .HasForeignKey(m => m.BusinessId)
            .HasPrincipalKey(b => b.Id);

    }
}
