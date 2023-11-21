using Application.Abstractions.Messaging;

namespace Application.OrderItems.AddDishToOrder;

public record AddDishToOrderCommand(Guid CustomerId, Guid DishId) : ICommand<AddDishToOrderResponse>;
