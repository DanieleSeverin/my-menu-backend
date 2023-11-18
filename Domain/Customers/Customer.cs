using Domain.Businesses;
using Domain.Orders;
using Domain.Tables;

namespace Domain.Customers;

public class Customer
{
    public CustomerId Id { get; init; }
    public BusinessId BusinessId { get; init; }
    public TableId TableId { get; init; }
    public List<Order> OrdersSent { get; init; }
    public Order CurrentOrder { get; set; }

    public Customer(BusinessId businessId, TableId tableId)
    {
        Id = CustomerId.New();
        BusinessId = businessId;
        TableId = tableId;
        OrdersSent = new List<Order>();
        CurrentOrder = new Order(Id);
    }

    public void SendOrder()
    {
        OrdersSent.Add(CurrentOrder);
        CurrentOrder = new Order(Id);
    }
}
