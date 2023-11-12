namespace Domain.Businesses;

public interface IBusinessRepository
{
    public Task<Business?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public void Add(Business business);
}
