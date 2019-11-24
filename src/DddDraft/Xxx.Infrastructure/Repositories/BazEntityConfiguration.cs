using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xxx.Domain.Aggregates.Bar;

namespace Xxx.Infrastructure.Repositories
{
    public class BazEntityConfiguration : IEntityTypeConfiguration<Baz>
    {
        public void Configure(EntityTypeBuilder<Baz> builder)
        {
            builder.ToTable("Bazs");

            builder.HasKey(x => x.Id);

            builder.Property("BarId").IsRequired();

            builder.Ignore(x => x.DomainEvents);
        }
    }
}
