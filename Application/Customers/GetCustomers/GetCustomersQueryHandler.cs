using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Customers;

namespace Application.Customers.GetCustomers;

internal sealed class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, List<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<List<Customer>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetAllAsync();
    }
}
