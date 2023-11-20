using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class OrderItemRepository : IOrderItemRepository
{
    private readonly ApplicationDbContext DbContext;

    public OrderItemRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<OrderItem?> GetByIdAsync(OrderItemId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<OrderItem>().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public void Remove(OrderItem orderItem)
    {
        DbContext.Remove<OrderItem>(orderItem);
    }

}
