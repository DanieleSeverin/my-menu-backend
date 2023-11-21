using Application.Abstractions.Messaging;

namespace Application.Orders.CancelOrder;

public record CancelOrderCommand(Guid OrderId) : ICommand;
