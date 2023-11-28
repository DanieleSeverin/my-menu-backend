using Application.Businesses.CreateBusiness;
using Application.Businesses.SearchBusinessBasicInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessController : ControllerBase
{
    private readonly ISender _sender;

    public BusinessController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{BusinessId}")]
    public async Task<IActionResult> GetBusinessBasicInfo(Guid BusinessId, CancellationToken cancellationToken)
    {
        var query = new BusinessBasicInfoQuery(BusinessId);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpPost()]
    public async Task<IActionResult> CreateBusiness(CancellationToken cancellationToken)
    {
        var command = new CreateBusinessCommand();

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }
}
