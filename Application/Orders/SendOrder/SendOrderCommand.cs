using Application.Abstractions.Messaging;

namespace Application.Orders.SendOrder;

public record SendOrderCommand(Guid CustomerId) : ICommand;
