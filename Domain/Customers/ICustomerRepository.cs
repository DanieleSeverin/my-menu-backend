using Domain.Businesses;

namespace Domain.Customers;

public interface ICustomerRepository
{
    public Task<Customer?> GetByIdAsync(CustomerId id, CancellationToken cancellationToken = default);
    public void Add(Customer customer);
}
