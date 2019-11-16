using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Xxx.Api.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected readonly IMediator _mediator;

        public ControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ActionResult> HandleCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
            where TCommand : IRequest<bool>
        {
            var commandResult = await _mediator.Send(command, cancellationToken);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
