using Domain.Businesses;
using Domain.Dishes;
using Domain.Tables;

namespace Domain.Menus;

public class Menu
{
    public MenuId Id { get; init; }
    public BusinessId BusinessId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public List<Dish> Dishes { get; private set; }

    public Business Business { get; private set; }

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
