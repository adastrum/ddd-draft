using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Common;

namespace Xxx.Domain.Aggregates.Bar
{
    public interface IBarRepository : IRepository<Bar>
    {
        Bar Add(Bar bar);

        Bar Update(Bar bar);

        void Delete(int barId);

        Task<Bar> GetByIdAsync(int barId, CancellationToken cancellationToken = default);
    }
}
