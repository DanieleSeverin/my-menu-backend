using Domain.Abstractions;

namespace Domain.Orders;

public static class OrderItemErrors
{
    public static Error NotFound = new(
    "OrderItem.Found",
    "The order item with the specified identifier was not found");
}
