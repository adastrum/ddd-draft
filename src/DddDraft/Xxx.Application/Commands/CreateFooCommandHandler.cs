using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Aggregates.Foo;

namespace Xxx.Application.Commands
{
    public class CreateFooCommandHandler : IRequestHandler<CreateFooCommand, bool>
    {
        private readonly IFooRepository _fooRepository;

        public CreateFooCommandHandler(IFooRepository fooRepository)
        {
            _fooRepository = fooRepository;
        }

        public async Task<bool> Handle(CreateFooCommand request, CancellationToken cancellationToken)
        {
            var fullName = new FullName(request.FirstName, request.MiddleName, request.SecondName);
            var foo = new Foo(fullName);

            _fooRepository.Add(foo);

            var result = await _fooRepository.UnitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
