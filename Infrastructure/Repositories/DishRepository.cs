using Domain.Dishes;
using Domain.Menus;

namespace Infrastructure.Repositories;

internal sealed class DishRepository : IDishRepository
{
    public Task<Dish?> GetByIdAsync(DishId id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Dish>> GetByMenuIdAsync(MenuId menuId)
    {
        throw new NotImplementedException();
    }
}
