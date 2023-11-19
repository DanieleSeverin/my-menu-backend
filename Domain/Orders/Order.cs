using Domain.Customers;

namespace Domain.Orders;

public class Order
{
    public OrderId Id { get; init; }
    public CustomerId CustomerId { get; init; }
    public bool Sent { get; set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyList<OrderItem> Items => _items.ToList();

    public Customer Customer { get; set; }

    public Order(CustomerId customerId)
    {
        Id = OrderId.New();
        CustomerId = customerId;
        Sent = false;
        _items = new List<OrderItem>();
    }

    public void Add(OrderItem item)
    {
        _items.Add(item);
    }

    public OrderItem? FindOrderItem(OrderItemId id)
    {
        return _items.Find(i => i.Id == id);
    }

    public bool IsOrderSent()
    {
        return Sent;
    }
}
