using Domain.Menus;
using Domain.Shared;

namespace Domain.Dishes;

public class Dish
{
    public DishId Id { get; init; }
    public MenuId MenuId { get; private set; }
    public string Name { get; private set; }
    public Money Price { get; private set; }

    public Menu Menu { get; private set; }

    public Dish(MenuId menuId, string name, Money price)
    {
        Id = DishId.New();
        MenuId = menuId;
        Name = name;
        Price = price;
    }

    private Dish() { }
}
