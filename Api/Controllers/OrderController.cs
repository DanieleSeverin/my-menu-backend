﻿using Application.Orders.CancelOrder;
using Application.Orders.SendOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ISender _sender;

    public OrderController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost("{CustomerId}")]
    public async Task<IActionResult> SendOrder(Guid CustomerId, CancellationToken cancellationToken)
    {
        var command = new SendOrderCommand(CustomerId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpDelete("{OrderId}")]
    public async Task<IActionResult> CancelOrder(Guid OrderId, CancellationToken cancellationToken)
    {
        var command = new CancelOrderCommand(OrderId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : NotFound(result.Error);
    }

}
