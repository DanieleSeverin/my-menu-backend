using Domain.Shared;

namespace Domain.Dishes;

public class Dish
{
    public DishId Id { get; init; }
    public string Name { get; init; }
    public Money Price { get; init; }

    public Dish(string name, Money price)
    {
        Id = DishId.New();
        Name = name;
        Price = price;
    }
}
