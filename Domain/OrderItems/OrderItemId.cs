namespace Domain.OrderItems;

public record OrderItemId(Guid Value)
{
    public static OrderItemId New() => new(Guid.NewGuid());
}
