using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Aggregates.Bar;

namespace Xxx.Application.Commands
{
    public class UpdateBarCommandHandler : IRequestHandler<UpdateBarCommand, bool>
    {
        private readonly IBarRepository _barRepository;

        public UpdateBarCommandHandler(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public async Task<bool> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = await _barRepository.GetByIdAsync(request.BarId, cancellationToken);

            if (bar == null)
            {
                return false;
            }

            foreach (var baz in request.Bazs)
            {
                bar.AddBaz(baz.Code, baz.Description);
            }

            bar.SetFooId(request.FooId);

            _barRepository.Update(bar);

            var result = await _barRepository.UnitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
