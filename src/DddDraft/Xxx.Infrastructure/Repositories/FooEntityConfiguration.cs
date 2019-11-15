using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xxx.Domain.Aggregates.Foo;

namespace Xxx.Infrastructure.Repositories
{
    public class FooEntityConfiguration : IEntityTypeConfiguration<Foo>
    {
        public void Configure(EntityTypeBuilder<Foo> builder)
        {
            builder.ToTable("Foos");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name);
        }
    }
}
