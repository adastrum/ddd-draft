using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Aggregates.Foo;
using Xxx.Domain.Common;

namespace Xxx.Infrastructure.Repositories
{
    public class FooRepository : IFooRepository
    {
        private readonly XxxContext _context;

        public FooRepository(XxxContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Foo Add(Foo foo)
        {
            return _context
                .Foos
                .Add(foo)
                .Entity;
        }

        public Task<Foo> GetByIdAsync(int fooId, CancellationToken cancellationToken = default)
        {
            return _context.Foos.FindAsync(fooId, cancellationToken);
        }
    }
}
