using Domain.Dishes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class DishConfigurations : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(dish => dish.Id);

        builder.Property(dish => dish.Id).HasConversion(
            dishId => dishId.Value,
            value => new DishId(value));

        builder.Property(c => c.Name).HasMaxLength(255);

        builder.OwnsOne(dish => dish.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

    }
}
