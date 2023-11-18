using Application.Orders.AddDishToOrder;
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
}
