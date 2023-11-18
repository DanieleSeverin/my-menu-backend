using Domain.Businesses;

namespace Domain.Customers;

public interface ICustomerRepository
{
    public Task<List<Customer>> GetAllAsync();
    public Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public void Add(Customer customer);
}
