namespace Domain.Orders;

public interface IOrderRepository
{
    public Task<Order?> GetByIdAsync(OrderId Id, CancellationToken cancellationToken = default);
    public void Add(Order order);
}
