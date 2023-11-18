using Domain.Businesses;
using Domain.Menus;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class MenuRepository : IMenuRepository
{
    private readonly ApplicationDbContext DbContext;

    public MenuRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<List<Menu>> GetByBusinessIdAsync(BusinessId businessId)
    {
        return await DbContext.Set<Menu>().Where(m => m.BusinessId == businessId).ToListAsync();
    }

    public async Task<Menu?> GetByIdAsync(MenuId id)
    {
        return await DbContext.Set<Menu>().FirstOrDefaultAsync(m => m.Id == id);
    }
}
