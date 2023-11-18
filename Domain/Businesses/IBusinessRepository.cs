namespace Domain.Businesses;

public interface IBusinessRepository
{
    public Task<Business?> GetByIdAsync(BusinessId id, CancellationToken cancellationToken = default);

    public void Add(Business business);
}
