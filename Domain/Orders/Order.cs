namespace Domain.Orders;

public class Order
{
    public Guid Id { get; init; }
    private bool Sent { get; set; }
    private List<OrderItem> Items { get; set; }

    public Order()
    {
        Id = Guid.NewGuid();
        Sent = false;
        Items = new List<OrderItem>();
    }

    public void Add(OrderItem item)
    {
        Items.Add(item);
    }

    public void Remove(OrderItem item)
    {
        Items.Remove(item);
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
