using Application.Abstractions.Messaging;

namespace Application.Orders.SearchOrderItems;

public sealed record SearchOrderItemsQuery(Guid BusinessId) : IQuery<IReadOnlyList<OrderItemsResponse>>;
