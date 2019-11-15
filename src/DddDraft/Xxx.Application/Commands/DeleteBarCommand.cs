using MediatR;

namespace Xxx.Application.Commands
{
    public class DeleteBarCommand : IRequest<bool>
    {
        public DeleteBarCommand(int barId)
        {
            BarId = barId;
        }

        public int BarId { get; private set; }
    }
}
