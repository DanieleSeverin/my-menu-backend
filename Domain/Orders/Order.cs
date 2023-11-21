using Domain.Customers;
using Domain.OrderItems;

namespace Domain.Orders;

public class Order
{
    public OrderId Id { get; init; }
    public CustomerId CustomerId { get; init; }
    public bool Sent { get; private set; }
    public bool Canceled { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyList<OrderItem> Items => _items.ToList();

    public Customer Customer { get; set; }

    public Order(CustomerId customerId)
    {
        Id = OrderId.New();
        CustomerId = customerId;
        Sent = false;
        Canceled = false;
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

    public void Send()
    {
        Sent = true;
    }

    public void Cancel()
    {
        Canceled = true;
    }
}
