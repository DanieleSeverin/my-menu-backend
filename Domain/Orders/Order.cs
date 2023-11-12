namespace Domain.Orders;

public class Order
{
    public Guid Id { get; init; }
    public Guid TableId { get; init; }
    private bool Sent { get; set; }

    private readonly List<OrderItem> _items = new();

    public Order(Guid tableId)
    {
        Id = Guid.NewGuid();
        TableId = tableId;
        Sent = false;
        _items = new List<OrderItem>();
    }

    public void Add(OrderItem item)
    {
        _items.Add(item);
    }

    public void Remove(OrderItem item)
    {
        _items.Remove(item);
    }

    public bool IsOrderSent()
    {
        return Sent;
    }

    public void SendOrder()
    {
        Sent = true;
    }
}
