using Application.Orders.AddDishToOrder;
using Application.Orders.MarkOrderItemsAsDelivered;
using Application.Orders.MarkOrderItemsAsPrepared;
using Application.Orders.RemoveDishFromOrder;
using Application.Orders.SearchOrderItems;
using Application.Orders.SendOrder;
using Domain.Customers;
using Domain.Dishes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    //[Authorize]
    [HttpGet("{BusinessId}")]
    public async Task<IActionResult> GetOrderItemSummary(Guid BusinessId, CancellationToken cancellationToken)
    {
        var query = new SearchOrderItemsQuery(BusinessId);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpPost("{CustomerId}")]
    public async Task<IActionResult> SendOrder(Guid CustomerId, CancellationToken cancellationToken)
    {
        var command = new SendOrderCommand(CustomerId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound();
    }

    //[Authorize]
    [HttpPut("Prepared/{OrderItemId}")]
    public async Task<IActionResult> MarkAsPrepared(Guid OrderItemId, CancellationToken cancellationToken)
    {
        var command = new MarkOrderItemsAsPreparedCommand(OrderItemId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    //[Authorize]
    [HttpPut("Delivered/{OrderItemId}")]
    public async Task<IActionResult> MarkAsDelivered(Guid OrderItemId, CancellationToken cancellationToken)
    {
        var command = new MarkOrderItemsAsDeliveredCommand(OrderItemId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpPut("{CustomerId}/{DishId}")]
    public async Task<IActionResult> AddDishToOrder(Guid CustomerId, Guid DishId, CancellationToken cancellationToken)
    {
        var command = new AddDishToOrderCommand(CustomerId, DishId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpDelete("{CustomerId}/{OrderItemId}")]
    public async Task<IActionResult> RemoveDishToOrder(Guid CustomerId, Guid OrderItemId, CancellationToken cancellationToken)
    {
        var command = new RemoveDishFromOrderCommand(CustomerId, OrderItemId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound();
    }
}
