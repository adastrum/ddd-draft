using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Common;

namespace Xxx.Domain.Aggregates.Foo
{
    public interface IFooRepository : IRepository<Foo>
    {
        Foo Add(Foo foo);

        Task<Foo> GetByIdAsync(int fooId, CancellationToken cancellationToken = default);
    }
}
