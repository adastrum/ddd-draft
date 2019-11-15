using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Xxx.Application.Commands
{
    public class UpdateBarCommand : IRequest<bool>
    {
        private readonly List<BazDto> _bazs;

        public UpdateBarCommand(int barId, IEnumerable<BazDto> bazs, int? fooId)
        {
            BarId = barId;
            _bazs = bazs.ToList();
            FooId = fooId;
        }

        public int BarId { get; private set; }

        public IReadOnlyCollection<BazDto> Bazs => _bazs.AsReadOnly();

        public int? FooId { get; private set; }
    }
}
