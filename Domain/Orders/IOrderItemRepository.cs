using Domain.Businesses;

namespace Domain.Orders;

public interface IOrderItemRepository
{
    public Task<OrderItem?> GetByIdAsync(OrderItemId id, CancellationToken cancellationToken = default);
    public void Remove(OrderItem orderItem);
}
