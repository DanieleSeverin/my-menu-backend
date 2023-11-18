using Application.Customers.ConnectCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ISender _sender;

    public CustomersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("connect/{BusinessId}/{TableId}")]
    public async Task<IActionResult> ConnectCustomer(Guid BusinessId, Guid TableId, CancellationToken cancellationToken)
    {
        var command = new ConnectCustomerCommand(BusinessId, TableId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

}
