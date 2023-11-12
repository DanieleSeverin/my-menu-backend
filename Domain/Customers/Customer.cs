using Domain.Orders;

namespace Domain.Customers;

public class Customer
{
    public Guid Id { get; init; }
    public Guid BusinessId { get; init; }
    public Guid TableId { get; init; }
    public List<Order> OrdersSent { get; init; }
    public Order CurrentOrder { get; set; }

    public Customer(Guid businessId, Guid tableId)
    {
        Id = Guid.NewGuid();
        BusinessId = businessId;
        TableId = tableId;
        OrdersSent = new List<Order>();
        CurrentOrder = new Order(TableId);
    }

    public void SendOrder()
    {
        OrdersSent.Add(CurrentOrder);
        CurrentOrder = new Order(TableId);
    }
}
