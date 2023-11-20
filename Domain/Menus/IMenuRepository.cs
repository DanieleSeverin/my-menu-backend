using Domain.Businesses;

namespace Domain.Menus;

public interface IMenuRepository
{
    public Task<Menu?> GetByIdAsync(MenuId id, CancellationToken cancellationToken = default);
    public Task<List<Menu>> GetByBusinessIdAsync(BusinessId businessId, CancellationToken cancellationToken = default);
}
