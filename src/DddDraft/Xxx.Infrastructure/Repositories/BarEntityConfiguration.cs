﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xxx.Domain.Aggregates.Bar;
using Xxx.Domain.Aggregates.Foo;

namespace Xxx.Infrastructure.Repositories
{
    public class BarEntityConfiguration : IEntityTypeConfiguration<Bar>
    {
        public void Configure(EntityTypeBuilder<Bar> builder)
        {
            builder.ToTable("Bars");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Bazs)
                .WithOne()
                .IsRequired()
                .HasForeignKey("BarId");

            builder
                .HasOne<Foo>()
                .WithMany()
                .IsRequired(false)
                .HasForeignKey("FooId");
        }
    }
}
