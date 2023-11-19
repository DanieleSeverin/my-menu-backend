using Domain.Orders;

namespace Infrastructure.Repositories;

internal sealed class OrderItemRepository : IOrderItemRepository
{
    private readonly ApplicationDbContext DbContext;

    public OrderItemRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Remove(OrderItem orderItem)
    {
        DbContext.Remove<OrderItem>(orderItem);
    }
}
