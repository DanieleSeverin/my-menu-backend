using Application.Orders.AddDishToOrder;
using Application.Orders.RemoveDishFromOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ISender _sender;

    public OrderController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPut("{CustomerId}/{DishId}")]
    public async Task<IActionResult> AddDishToOrder(Guid CustomerId, Guid DishId, CancellationToken cancellationToken)
    {
        var command = new AddDishToOrderCommand(CustomerId, DishId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpDelete("{CustomerId}/{OrderItemId}")]
    public async Task<IActionResult> RemoveDishToOrder(Guid CustomerId, Guid OrderItemId, CancellationToken cancellationToken)
    {
        var command = new RemoveDishFromOrderCommand(CustomerId, OrderItemId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound();
    }
}
