using Application.Abstractions.Messaging;

namespace Application.Orders.AddDishToOrder;

public record AddDishToOrderCommand(Guid CustomerId, Guid DishId) : ICommand<Guid>;
