using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext DbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Order?> GetByIdAsync(OrderId Id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Order>().FirstOrDefaultAsync(o => o.Id == Id, cancellationToken);
    }

    public void Add(Order order)
    {
        DbContext.Add<Order>(order);
    }
}
