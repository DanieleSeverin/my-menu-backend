using Domain.Dishes;
using Domain.Orders;

namespace Domain.OrderItems;

public class OrderItem
{
    public OrderItemId Id { get; init; }
    public DishId DishId { get; private set; }
    public OrderId OrderId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? PreparedAt { get; private set; }
    public DateTime? DeliveredAt { get; private set; }

    public Order Order { get; private set; }
    public Dish Dish { get; private set; }

    public OrderItem(OrderId orderId, DishId dishId)
    {
        Id = OrderItemId.New();
        OrderId = orderId;
        DishId = dishId;
        CreatedAt = DateTime.Now;
    }

    private OrderItem() { }

    public void Prepared()
    {
        PreparedAt = DateTime.Now;
    }

    public void Delivered()
    {
        DeliveredAt = DateTime.Now;
    }
}
