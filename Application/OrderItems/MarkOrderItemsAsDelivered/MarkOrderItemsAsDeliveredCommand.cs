using Application.Abstractions.Messaging;

namespace Application.OrderItems.MarkOrderItemsAsDelivered;

public record MarkOrderItemsAsDeliveredCommand(Guid OrderItemId) : ICommand;
