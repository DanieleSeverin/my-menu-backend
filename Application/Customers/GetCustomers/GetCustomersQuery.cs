using Application.Abstractions.Messaging;
using Domain.Customers;

namespace Application.Customers.GetCustomers;

public sealed record GetCustomersQuery() : IQuery<List<Customer>>
{
}
