using Domain.Abstractions;

namespace Domain.Orders;

public static class OrderErrors
{
    public static Error NotFound = new(
    "Order.Found",
    "The order with the specified identifier was not found");
}
