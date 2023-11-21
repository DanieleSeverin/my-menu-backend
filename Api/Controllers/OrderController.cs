﻿using Application.Orders.SendOrder;
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

    [HttpPost("{CustomerId}")]
    public async Task<IActionResult> SendOrder(Guid CustomerId, CancellationToken cancellationToken)
    {
        var command = new SendOrderCommand(CustomerId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound();
    }

}
