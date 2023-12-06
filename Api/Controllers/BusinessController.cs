using Application.Businesses.CreateBusiness;
using Application.Businesses.SearchBusiness;
using Application.Businesses.SearchBusinessExtendedInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BusinessController : ControllerBase
{
    private readonly ISender _sender;

    public BusinessController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet("{BusinessId}")]
    public async Task<IActionResult> SearchBusiness(Guid BusinessId, CancellationToken cancellationToken)
    {
        var query = new SearchBusinessQuery(BusinessId);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }

    [AllowAnonymous]
    [HttpGet("{BusinessId}/extended")]
    public async Task<IActionResult> SearchBusinessExtendedInfo(Guid BusinessId, CancellationToken cancellationToken)
    {
        var query = new BusinessExtendedInfoQuery(BusinessId);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }

    [HttpPost()]
    public async Task<IActionResult> CreateBusiness(CancellationToken cancellationToken)
    {
        var command = new CreateBusinessCommand();

        var result = await _sender.Send(command, cancellationToken);

        var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/api";
        string createdUri = $"{baseUri}/business/{result.Value}";

        return Created(createdUri, result);
    }
}
