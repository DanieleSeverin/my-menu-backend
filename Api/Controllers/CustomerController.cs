using Application.Customers.ConnectCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ISender _sender;

    public CustomerController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost("connect/{BusinessId}/{TableId}")]
    public async Task<IActionResult> ConnectCustomer(Guid BusinessId, Guid TableId, CancellationToken cancellationToken)
    {
        var command = new ConnectCustomerCommand(BusinessId, TableId);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }

}
