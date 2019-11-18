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

        protected async Task<ActionResult> HandleQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken)
            where TQuery : IRequest<TResult>
        {
            var queryResult = await _mediator.Send(query, cancellationToken);

            return Ok(queryResult);
        }
    }
}
