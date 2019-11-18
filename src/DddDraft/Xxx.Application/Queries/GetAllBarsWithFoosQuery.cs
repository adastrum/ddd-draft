using MediatR;
using System.Collections.Generic;

namespace Xxx.Application.Queries
{
    public class GetAllBarsWithFoosQuery : IRequest<IEnumerable<BarDto>>
    {
    }
}
