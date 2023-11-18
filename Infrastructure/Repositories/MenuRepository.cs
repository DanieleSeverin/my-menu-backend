using Domain.Businesses;
using Domain.Menus;

namespace Infrastructure.Repositories;

internal sealed class MenuRepository : IMenuRepository
{
    public Task<List<Menu>> GetByBusinessIdAsync(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public Task<Menu?> GetByIdAsync(MenuId id)
    {
        throw new NotImplementedException();
    }
}
