using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Application.Queries;

namespace Xxx.Infrastructure.Queries
{
    public class GetAllBarsWithFoosQueryHandler : IRequestHandler<GetAllBarsWithFoosQuery, IEnumerable<BarDto>>
    {
        private readonly IBarService _barService;

        public GetAllBarsWithFoosQueryHandler(IBarService barService)
        {
            _barService = barService;
        }

        public async Task<IEnumerable<BarDto>> Handle(GetAllBarsWithFoosQuery request, CancellationToken cancellationToken)
        {
            var result = await _barService.GetAllBarsWithFoos(cancellationToken);

            return result;
        }
    }
}
