using Application.Abstractions.Messaging;

namespace Application.Orders.MarkOrderItemsAsPrepared;

public record MarkOrderItemsAsPreparedCommand(Guid OrderItemId) : ICommand;
