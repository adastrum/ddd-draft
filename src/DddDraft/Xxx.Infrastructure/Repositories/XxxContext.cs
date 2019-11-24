using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Aggregates.Bar;
using Xxx.Domain.Aggregates.Foo;
using Xxx.Domain.Common;

namespace Xxx.Infrastructure.Repositories
{
    public class XxxContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public XxxContext()
        {

        }

        public XxxContext(DbContextOptions<XxxContext> options) : base(options)
        {

        }

        public XxxContext(DbContextOptions<XxxContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Foo> Foos { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Baz> Bazs { get; set; }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this, cancellationToken);

            var result = await base.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FooEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BarEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BazEntityConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Xxx;Integrated Security=True");
            }
        }
    }

    public static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, XxxContext ctx, CancellationToken cancellationToken = default)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities
                .ToList()
                .ForEach(x => x.Entity.DomainEvents.Clear());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.Publish(domainEvent, cancellationToken);
                });

            await Task.WhenAll(tasks);
        }
    }
}
