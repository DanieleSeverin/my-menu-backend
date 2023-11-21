using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Businesses;

namespace Application.OrderItems.GetOrderItemSummary;

internal sealed class GetOrderItemSummaryQueryHandler : IQueryHandler<GetOrderItemSummaryQuery, IReadOnlyList<OrderItemsResponse>>
{
    private readonly IOrderItemSummary _orderItemSummary;

    public GetOrderItemSummaryQueryHandler(IOrderItemSummary orderItemSummary)
    {
        _orderItemSummary = orderItemSummary;
    }

    public async Task<Result<IReadOnlyList<OrderItemsResponse>>> Handle(GetOrderItemSummaryQuery request, CancellationToken cancellationToken)
    {
        return Result.Success(await _orderItemSummary.Get(new BusinessId(request.BusinessId)));
    }
}
