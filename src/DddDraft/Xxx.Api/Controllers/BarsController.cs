using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Application.Commands;
using Xxx.Infrastructure.Queries;

namespace Xxx.Api.Controllers
{
    [Route("api/[controller]")]
    public class BarsController : ControllerBase
    {
        private readonly BarQueryHandler _barQueryHandler;

        public BarsController(IMediator mediator, BarQueryHandler barQueryHandler) : base(mediator)
        {
            _barQueryHandler = barQueryHandler;
        }

        [HttpGet("bars")]
        public async Task<ActionResult<IEnumerable<BarDto>>> GetAllBarsWithFoos()
        {
            var result = await _barQueryHandler.GetAllBarsWithFoos();

            return Ok(result);
        }

        [HttpPost("bars")]
        public async Task<ActionResult> CreateBarAsync([FromBody]CreateBarCommand createBarCommand, CancellationToken cancellationToken) =>
            await HandleCommandAsync(createBarCommand, cancellationToken);

        [HttpPatch("bars")]
        public async Task<ActionResult> UpdateBarAsync([FromBody]UpdateBarCommand updateBarCommand, CancellationToken cancellationToken) =>
            await HandleCommandAsync(updateBarCommand, cancellationToken);

        [HttpDelete("bars")]
        public async Task<ActionResult> DeleteBarAsync([FromBody]DeleteBarCommand deleteBarCommand, CancellationToken cancellationToken) =>
            await HandleCommandAsync(deleteBarCommand, cancellationToken);

    }
}
