using Domain.Abstractions;

namespace Domain.OrderItems;

public static class OrderItemErrors
{
    public static Error NotFound = new(
    "OrderItem.Found",
    "The order item with the specified identifier was not found");
}
