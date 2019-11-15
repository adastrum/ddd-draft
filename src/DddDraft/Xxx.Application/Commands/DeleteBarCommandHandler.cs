using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Xxx.Domain.Aggregates.Bar;

namespace Xxx.Application.Commands
{
    public class DeleteBarCommandHandler : IRequestHandler<DeleteBarCommand, bool>
    {
        private readonly IBarRepository _barRepository;

        public DeleteBarCommandHandler(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public async Task<bool> Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            await _barRepository.DeleteAsync(request.BarId, cancellationToken);

            var result = await _barRepository.UnitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
