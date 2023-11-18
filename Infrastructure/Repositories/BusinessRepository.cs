using Domain.Businesses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class BusinessRepository : IBusinessRepository
{
    private readonly ApplicationDbContext DbContext;

    public BusinessRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(Business business)
    {
        DbContext.Add<Business>(business);
    }

    public async Task<Business?> GetByIdAsync(BusinessId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Business>()
            .Include(b => b.Tables)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }
}
