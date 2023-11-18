using Domain.Menus;

namespace Infrastructure.Repositories;

internal sealed class MenuRepository : IMenuRepository
{
    public Task<List<Menu>> GetByBusinessIdAsync(Guid businessId)
    {
        throw new NotImplementedException();
    }

    public Task<Menu?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
