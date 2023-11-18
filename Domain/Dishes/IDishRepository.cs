using Domain.Menus;

namespace Domain.Dishes;

public interface IDishRepository
{
    public Task<Dish?> GetByIdAsync(DishId id);
    public Task<List<Dish>> GetByMenuIdAsync(MenuId menuId);
}
