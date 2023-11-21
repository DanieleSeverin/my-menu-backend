using Application.Abstractions.Messaging;

namespace Application.OrderItems.RemoveDishFromOrder;

public record RemoveDishFromOrderCommand(Guid CustomerId, Guid OrderItemId) : ICommand;
