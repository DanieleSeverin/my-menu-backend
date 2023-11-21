using Domain.Businesses;

namespace Application.OrderItems.SearchOrderItems;

public interface IOrderItemSummary
{
    public Task<IReadOnlyList<OrderItemsResponse>> Get(BusinessId BusinessId, CancellationToken cancellationToken = default);
}
