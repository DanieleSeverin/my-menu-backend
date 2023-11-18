using Domain.Dishes;

namespace Infrastructure.Repositories;

internal sealed class DishRepository : IDishRepository
{
    public Task<Dish?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Dish>> GetByMenuIdAsync(Guid menuId)
    {
        throw new NotImplementedException();
    }
}
