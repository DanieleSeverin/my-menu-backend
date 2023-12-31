﻿using Application.OrderItems.AddDishToOrder;
using Application.OrderItems.GetOrderItemSummary;
using Application.OrderItems.MarkOrderItemsAsDelivered;
using Application.OrderItems.MarkOrderItemsAsPrepared;
using Application.OrderItems.RemoveDishFromOrder;
using Application.Orders.SendOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly ISender _sender;

    public OrderItemController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{BusinessId}")]
    public async Task<IActionResult> GetOrderItemSummary(Guid BusinessId, CancellationToken cancellationToken)
    {
        var query = new GetOrderItemSummaryQuery(BusinessId);

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPut("Prepared/{OrderItemId}")]
    public async Task<IActionResult> MarkAsPrepared(Guid OrderItemId, CancellationToken cancellationToken)
    {
        var command = new MarkOrderItemsAsPreparedCommand(OrderItemId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }

    [HttpPut("Delivered/{OrderItemId}")]
    public async Task<IActionResult> MarkAsDelivered(Guid OrderItemId, CancellationToken cancellationToken)
    {
        var command = new MarkOrderItemsAsDeliveredCommand(OrderItemId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }

    [AllowAnonymous]
    [HttpPut("{CustomerId}/{DishId}")]
    public async Task<IActionResult> AddDishToOrder(Guid CustomerId, Guid DishId, CancellationToken cancellationToken)
    {
        var command = new AddDishToOrderCommand(CustomerId, DishId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }

    [AllowAnonymous]
    [HttpDelete("{CustomerId}/{OrderItemId}")]
    public async Task<IActionResult> RemoveDishFromOrder(Guid CustomerId, Guid OrderItemId, CancellationToken cancellationToken)
    {
        var command = new RemoveDishFromOrderCommand(CustomerId, OrderItemId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : NotFound(result.Error);
    }
}
