using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext DbContext;

    public CustomerRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(Customer customer)
    {
        DbContext.Add<Customer>(customer);
    }

    public async Task<Customer?> GetByIdAsync(CustomerId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Customer>()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }
}
