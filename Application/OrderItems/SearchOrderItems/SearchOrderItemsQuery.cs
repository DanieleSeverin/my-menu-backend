using Application.Abstractions.Messaging;

namespace Application.OrderItems.SearchOrderItems;

public sealed record SearchOrderItemsQuery(Guid BusinessId) : IQuery<IReadOnlyList<OrderItemsResponse>>;
