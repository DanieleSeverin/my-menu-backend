using Application.Abstractions.Messaging;

namespace Application.OrderItems.GetOrderItemSummary;

public sealed record GetOrderItemSummaryQuery(Guid BusinessId) : IQuery<IReadOnlyList<OrderItemsResponse>>;
