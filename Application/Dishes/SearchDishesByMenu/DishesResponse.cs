using Domain.Dishes;
using Domain.Shared;

namespace Application.Dishes.SearchDishesByMenu;

public sealed class DishesResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public Money Price { get; init; }

    public DishesResponse(Dish dishEntity)
    {
        Id = dishEntity.Id.Value;
        Name = dishEntity.Name;
        Price = dishEntity.Price;
    }
}
