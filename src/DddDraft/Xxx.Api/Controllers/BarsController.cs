using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Application.Commands;
using Xxx.Application.Queries;

namespace Xxx.Api.Controllers
{
    [Route("api/[controller]")]
    public class BarsController : ControllerBase
    {
        public BarsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarDto>>> GetAllBarsWithFoos(CancellationToken cancellationToken) =>
            await HandleQueryAsync<GetAllBarsWithFoosQuery, IEnumerable<BarDto>>(new GetAllBarsWithFoosQuery(), cancellationToken);

        [HttpPost]
        public async Task<ActionResult> CreateBarAsync([FromBody]CreateBarCommand createBarCommand, CancellationToken cancellationToken) =>
            await HandleCommandAsync(createBarCommand, cancellationToken);

        [HttpPatch]
        public async Task<ActionResult> UpdateBarAsync([FromBody]UpdateBarCommand updateBarCommand, CancellationToken cancellationToken) =>
            await HandleCommandAsync(updateBarCommand, cancellationToken);

        [HttpDelete]
        public async Task<ActionResult> DeleteBarAsync([FromBody]DeleteBarCommand deleteBarCommand, CancellationToken cancellationToken) =>
            await HandleCommandAsync(deleteBarCommand, cancellationToken);

    }
}
