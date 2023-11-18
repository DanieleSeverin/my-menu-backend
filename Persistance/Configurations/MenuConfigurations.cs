using Domain.Businesses;
using Domain.Menus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

internal class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            menuId => menuId.Value,
            value => new MenuId(value));
    }
}
