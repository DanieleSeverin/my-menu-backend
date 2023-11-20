using Application.Abstractions.Messaging;

namespace Application.Orders.MarkOrderItemsAsDelivered;

public record MarkOrderItemsAsDeliveredCommand(Guid OrderItemId) : ICommand;
