using Domain.Businesses;

namespace Infrastructure.Repositories;

internal sealed class BusinessRepository : IBusinessRepository
{
    public void Add(Business business)
    {
        throw new NotImplementedException();
    }

    public Task<Business?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
