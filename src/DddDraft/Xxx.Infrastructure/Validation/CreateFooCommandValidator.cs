using FluentValidation;
using Xxx.Application.Commands;

namespace Xxx.Infrastructure.Validation
{
    public class CreateFooCommandValidator : AbstractValidator<CreateFooCommand>
    {
        public CreateFooCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.MiddleName).NotEmpty();
            RuleFor(x => x.SecondName).NotEmpty();
        }
    }
}
