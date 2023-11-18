using Domain.Businesses;
using Domain.Dishes;
using Domain.Tables;

namespace Domain.Menus;

public class Menu
{
    public MenuId Id { get; init; }
    public BusinessId BusinessId { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public bool IsActive { get; set; }
    public List<Dish> Dishes { get; init; }

    public Business Business { get; init; }

    public Menu(BusinessId businessId, string name, string? description)
    {
        Id = MenuId.New();
        BusinessId = businessId;
        Name = name;
        Description = description;
        IsActive = false;
        Dishes = new List<Dish>();
    }

    public void AddDish(Dish dish)
    {
        Dishes.Add(dish);
    }

    public void RemoveDish(DishId dishId)
    {
        var dish = Dishes.FirstOrDefault(x => x.Id.Value == dishId.Value);
        if (dish is not null)
        {
            Dishes.Remove(dish);
        }
    }

    public void ActivateMenu()
    {
        IsActive = true;
    }

    public void DeactivateMenu()
    {
        IsActive = false;
    }
}
