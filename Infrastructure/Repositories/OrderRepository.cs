using Domain.Orders;

namespace Infrastructure.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext DbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(Order order)
    {
        DbContext.Add<Order>(order);
    }
}
