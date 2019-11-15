using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Aggregates.Bar;

namespace Xxx.Application.Commands
{
    public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand, bool>
    {
        private readonly IBarRepository _barRepository;

        public CreateBarCommandHandler(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public async Task<bool> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = new Bar();

            foreach (var baz in request.Bazs)
            {
                bar.AddBaz(baz.Code, baz.Description);
            }

            bar.SetFooId(request.FooId);

            _barRepository.Add(bar);

            var result = await _barRepository.UnitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
