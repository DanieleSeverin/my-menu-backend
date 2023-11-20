using Domain.Menus;

namespace Domain.Dishes;

public interface IDishRepository
{
    public Task<Dish?> GetByIdAsync(DishId id, CancellationToken cancellationToken = default);
    public Task<List<Dish>> GetByMenuIdAsync(MenuId menuId, CancellationToken cancellationToken = default);
}
