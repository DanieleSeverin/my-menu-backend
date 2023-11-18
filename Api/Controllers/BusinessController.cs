using Application.Businesses.SearchBusinessBasicInfo;
using Application.Customers.ConnectCustomer;
using Domain.Businesses;
using Domain.Tables;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Api.Controllers
{
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

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
    }
}
