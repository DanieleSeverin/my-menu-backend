using Domain.Businesses;
using Domain.Customers;
using Domain.Menus;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(menu => menu.Id);

        builder.Property(menu => menu.Id).HasConversion(
            menuId => menuId.Value,
            value => new MenuId(value));

        builder.Property(menu => menu.BusinessId).HasConversion(
            businessId => businessId.Value,
            value => new BusinessId(value));

        builder.Property(menu => menu.Name).IsRequired().HasMaxLength(255);

        builder.Property(menu => menu.Description).HasMaxLength(255);

        builder.HasMany(menu => menu.Dishes)
            .WithOne(dish => dish.Menu)
            .HasForeignKey(dish => dish.MenuId)
            .HasPrincipalKey(b => b.Id);

    }
}
