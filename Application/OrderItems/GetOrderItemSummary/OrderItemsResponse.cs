namespace Application.OrderItems.GetOrderItemSummary;

public sealed class OrderItemsResponse
{
    public Guid TableId { get; set; }
    public string TableIdentifier { get; set; } = string.Empty;
    public Guid DishId { get; set; }
    public string DishName { get; set; } = string.Empty;
    public bool Prepared { get; set; }
    public bool Canceled { get; set; }
}
