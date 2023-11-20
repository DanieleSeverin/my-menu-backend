using Domain.Businesses;

namespace Application.Orders.SearchOrderItems;

public interface IOrderItemSummary
{
    public Task<IReadOnlyList<OrderItemsResponse>> Get(BusinessId BusinessId, CancellationToken cancellationToken = default);
}
