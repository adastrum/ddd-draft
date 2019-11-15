using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Aggregates.Bar;
using Xxx.Domain.Common;

namespace Xxx.Infrastructure.Repositories
{
    public class BarRepository : IBarRepository
    {
        private readonly XxxContext _context;

        public BarRepository(XxxContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Bar Add(Bar bar)
        {
            return _context
                .Bars
                .Add(bar)
                .Entity;
        }

        public async Task DeleteAsync(int barId, CancellationToken cancellationToken = default)
        {
            var bar = await GetByIdAsync(barId, cancellationToken);

            _context.Remove(bar);
        }

        public Task<Bar> GetByIdAsync(int barId, CancellationToken cancellationToken = default)
        {
            return _context
                .Bars
                .FindAsync(barId, cancellationToken);
        }

        public Bar Update(Bar bar)
        {
            return _context
                .Bars
                .Update(bar)
                .Entity;
        }
    }
}
