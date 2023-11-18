using Domain.Abstractions;

namespace Domain.Customers;

public static class CustomerErrors
{
    public static Error NotFound = new(
    "Customer.Found",
    "The customer with the specified identifier was not found");

    public static Error NoCurrentOrder = new(
    "Customer.CurrentOrder",
    "The customer does not have a current order.");
}
