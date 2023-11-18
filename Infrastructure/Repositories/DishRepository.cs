using Domain.Dishes;
using Domain.Menus;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class DishRepository : IDishRepository
{
    private readonly ApplicationDbContext DbContext;

    public DishRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Dish?> GetByIdAsync(DishId id)
    {
        return await DbContext.Set<Dish>().FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<List<Dish>> GetByMenuIdAsync(MenuId menuId)
    {
        return await DbContext.Set<Dish>().Where(d => d.MenuId == menuId).ToListAsync();
    }
}
