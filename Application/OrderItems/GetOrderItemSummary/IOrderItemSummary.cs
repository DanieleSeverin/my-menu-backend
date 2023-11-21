using Domain.Businesses;

namespace Application.OrderItems.GetOrderItemSummary;

public interface IOrderItemSummary
{
    public Task<IReadOnlyList<OrderItemsResponse>> Get(BusinessId BusinessId, CancellationToken cancellationToken = default);
}
