using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Domain.Aggregates.Bar;
using Xxx.Domain.Aggregates.Foo;
using Xxx.Domain.Common;

namespace Xxx.Infrastructure.Repositories
{
    public class XxxContext : DbContext, IUnitOfWork
    {
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Baz> Bazs { get; set; }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
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
}
