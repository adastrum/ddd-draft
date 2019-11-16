using MediatR;

namespace Xxx.Application.Commands
{
    public class CreateFooCommand : IRequest<bool>
    {
        public CreateFooCommand(string firstName, string middleName, string secondName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            SecondName = secondName;
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string SecondName { get; private set; }
    }
}
