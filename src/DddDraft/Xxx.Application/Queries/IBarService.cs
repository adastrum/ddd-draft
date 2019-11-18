using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Xxx.Application.Queries
{
    public interface IBarService
    {
        Task<IEnumerable<BarDto>> GetAllBarsWithFoos(CancellationToken cancellationToken = default);
    }
}
