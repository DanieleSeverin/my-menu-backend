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
        throw new NotImplementedException();
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await DbContext.Set<Customer>()
            //.Include(customer => customer.Orders)
            .Include(customer => customer.Table)
            .ToListAsync();
    }

    public Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
