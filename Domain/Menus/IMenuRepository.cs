namespace Domain.Menus;

public interface IMenuRepository
{
    public Task<Menu?> GetByIdAsync(Guid id);
    public Task<List<Menu>> GetByBusinessIdAsync(Guid businessId);
}
