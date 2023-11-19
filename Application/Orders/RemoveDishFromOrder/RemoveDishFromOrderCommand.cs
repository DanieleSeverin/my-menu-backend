using Application.Abstractions.Messaging;

namespace Application.Orders.RemoveDishFromOrder;

public record RemoveDishFromOrderCommand(Guid CustomerId, Guid OrderItemId) : ICommand;
