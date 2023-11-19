namespace Domain.Orders;

public interface IOrderItemRepository
{
    public void Remove(OrderItem orderItem);
}
