namespace Domain.Orders;

public class OrderItem
{
    public Guid Id { get; init; }
    public Guid DishId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? PreparedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }

    public OrderItem(Guid dishId)
    {
        Id = Guid.NewGuid();
        DishId = dishId;
        CreatedAt = DateTime.Now;
    }

    public void Prepared()
    {
        PreparedAt = DateTime.Now;
    }

    public void Delivered()
    {
        DeliveredAt = DateTime.Now;
    }
}
