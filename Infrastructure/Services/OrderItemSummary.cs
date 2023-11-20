using Application.Orders.SearchOrderItems;
using Domain.Businesses;
using Domain.Customers;
using Domain.Dishes;
using Domain.Orders;
using Domain.Tables;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class OrderItemSummary : IOrderItemSummary
{
    private readonly ApplicationDbContext DbContext;

    public OrderItemSummary(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<IReadOnlyList<OrderItemsResponse>> Get(BusinessId BusinessId, CancellationToken cancellationToken = default)
    {
        var query = from oi in DbContext.Set<OrderItem>()
                    join o in DbContext.Set<Order>() on oi.OrderId equals o.Id
                    join c in DbContext.Set<Customer>() on o.CustomerId equals c.Id
                    join ti in DbContext.Set<Table>() on c.TableId equals ti.Id
                    join d in DbContext.Set<Dish>() on oi.DishId equals d.Id
                    where ti.BusinessId == BusinessId && oi.DeliveredAt == null
                    select new OrderItemsResponse
                    {
                        TableId = ti.Id.Value,
                        TableIdentifier = ti.TableIdentifier.Value,
                        DishId = oi.DishId.Value,
                        DishName = d.Name,
                        Prepared = oi.PreparedAt != null
                    };

        return await query.ToListAsync(cancellationToken);
    }
}
