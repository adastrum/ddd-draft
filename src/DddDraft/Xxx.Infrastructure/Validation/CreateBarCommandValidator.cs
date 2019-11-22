using FluentValidation;
using Xxx.Application.Commands;

namespace Xxx.Infrastructure.Validation
{
    public class CreateBarCommandValidator : AbstractValidator<CreateBarCommand>
    {
        public CreateBarCommandValidator()
        {
            RuleFor(x => x.Bazs).NotNull();
            RuleForEach(x => x.Bazs).NotNull();
            RuleForEach(x => x.Bazs).Must(x => !string.IsNullOrEmpty(x.Code) && !string.IsNullOrEmpty(x.Description));
        }
    }
}
