using Application.Abstractions.Messaging;

namespace Application.OrderItems.MarkOrderItemsAsPrepared;

public record MarkOrderItemsAsPreparedCommand(Guid OrderItemId) : ICommand;
