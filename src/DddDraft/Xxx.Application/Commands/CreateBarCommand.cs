using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Xxx.Application.Commands
{
    public class CreateBarCommand : IRequest<bool>
    {
        private readonly List<BazDto> _bazs;

        public CreateBarCommand(IEnumerable<BazDto> bazs, int? fooId)
        {
            _bazs = bazs.ToList();
            FooId = fooId;
        }

        public IReadOnlyCollection<BazDto> Bazs => _bazs.AsReadOnly();

        public int? FooId { get; private set; }
    }
}
