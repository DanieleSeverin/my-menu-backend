using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Businesses;

namespace Application.Orders.SearchOrderItems;

internal sealed class SearchOrderItemsQueryHandler : IQueryHandler<SearchOrderItemsQuery, IReadOnlyList<OrderItemsResponse>>
{
    private readonly IOrderItemSummary _orderItemSummary;

    public SearchOrderItemsQueryHandler(IOrderItemSummary orderItemSummary)
    {
        _orderItemSummary = orderItemSummary;
    }

    public async Task<Result<IReadOnlyList<OrderItemsResponse>>> Handle(SearchOrderItemsQuery request, CancellationToken cancellationToken)
    {
        return Result.Success( await _orderItemSummary.Get( new BusinessId(request.BusinessId) ));
    }
}
