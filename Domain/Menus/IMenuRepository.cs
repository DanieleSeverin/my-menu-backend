using Domain.Businesses;

namespace Domain.Menus;

public interface IMenuRepository
{
    public Task<Menu?> GetByIdAsync(MenuId id);
    public Task<List<Menu>> GetByBusinessIdAsync(BusinessId businessId);
}
