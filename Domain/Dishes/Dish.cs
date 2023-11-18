using Domain.Menus;
using Domain.Shared;

namespace Domain.Dishes;

public class Dish
{
    public DishId Id { get; init; }
    public MenuId MenuId { get; init; }
    public string Name { get; init; }
    public Money Price { get; init; }

    public Menu Menu { get; init; }

    public Dish(MenuId menuId, string name, Money price)
    {
        Id = DishId.New();
        MenuId = menuId;
        Name = name;
        Price = price;
    }

    private Dish() { }
}
