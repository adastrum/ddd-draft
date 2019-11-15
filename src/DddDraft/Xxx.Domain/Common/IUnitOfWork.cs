using System.Threading;
using System.Threading.Tasks;

namespace Xxx.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    }
}
