using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Application.Commands;

namespace Xxx.Api.Controllers
{
    [Route("api/[controller]")]
    public class FoosController : ControllerBase
    {
        public FoosController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("foos")]
        public async Task<ActionResult> CreateFooAsync([FromBody]CreateFooCommand createFooCommand, CancellationToken cancellationToken) =>
            await HandleCommandAsync(createFooCommand, cancellationToken);
    }
}
