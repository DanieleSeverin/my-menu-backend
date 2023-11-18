using Domain.Dishes;

namespace Domain.Menus;

public class Menu
{
    public MenuId Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public bool IsActive { get; set; }
    public List<Dish> Dishes { get; init; }

    public Menu(string name, string? description)
    {
        Id = MenuId.New();
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
