using Domain.Abstractions;
using Domain.Businesses;
using Domain.Orders;
using Domain.Tables;

namespace Domain.Customers;

public class Customer
{
    public CustomerId Id { get; init; }
    public BusinessId BusinessId { get; init; }
    public TableId TableId { get; init; }
    public List<Order> Orders { get; init; }
    public Table Table { get; init; }

    public Customer(BusinessId businessId, TableId tableId)
    {
        Id = CustomerId.New();
        BusinessId = businessId;
        TableId = tableId;
        Orders = new List<Order>();
    }

    public Result<Order> GetCurrentOrder()
    {
        var currentOrder = Orders.FirstOrDefault(x => x.Sent == false);
        if (currentOrder is null)
        {
            return Result.Failure<Order>(CustomerErrors.NoCurrentOrder);
        }

        return Result.Success(currentOrder);
    }

    public Result SendOrder()
    {
        var getCurrentOrderResult = GetCurrentOrder();
        Orders.Add(new Order(Id));

        if (getCurrentOrderResult.IsFailure)
        {
            return Result.Failure(CustomerErrors.NoCurrentOrder);
        }

        var currentOrder = getCurrentOrderResult.Value;
        currentOrder.Send();

        return Result.Success();
    }
}
