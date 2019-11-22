using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Exceptions;

namespace Xxx.Infrastructure.Validation
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior()
        {

        }

        public ValidatorBehavior(IValidator<TRequest> validator)
        {
            _validators = new[] { validator };
        }

        public ValidatorBehavior(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators != null)
            {
                var failures = _validators
                    .Select(x => x.Validate(request))
                    .SelectMany(x => x.Errors)
                    .Where(x => x != null)
                    .ToList();

                if (failures.Any())
                {
                    throw new XxxDomainException($"Command Validation Errors for type {typeof(TRequest).Name}",
                        new ValidationException("Validation exception", failures));
                }
            }

            var response = await next();

            return response;
        }
    }
}
