namespace Domain.Dishes;

public interface IDishRepository
{
    public Task<Dish?> GetByIdAsync(Guid id);
    public Task<List<Dish>> GetByMenuIdAsync(Guid menuId);
}
