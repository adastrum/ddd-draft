﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xxx.Infrastructure.Repositories;

namespace Xxx.Infrastructure.Migrations
{
    [DbContext(typeof(XxxContext))]
    partial class XxxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Xxx.Domain.Aggregates.Bar.Bar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<int?>("FooId");

                    b.HasKey("Id");

                    b.HasIndex("FooId");

                    b.ToTable("Bars");
                });

            modelBuilder.Entity("Xxx.Domain.Aggregates.Bar.Baz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarId");

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.ToTable("Bazs");
                });

            modelBuilder.Entity("Xxx.Domain.Aggregates.Foo.Foo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Foos");
                });

            modelBuilder.Entity("Xxx.Domain.Aggregates.Bar.Bar", b =>
                {
                    b.HasOne("Xxx.Domain.Aggregates.Foo.Foo")
                        .WithMany()
                        .HasForeignKey("FooId");
                });

            modelBuilder.Entity("Xxx.Domain.Aggregates.Bar.Baz", b =>
                {
                    b.HasOne("Xxx.Domain.Aggregates.Bar.Bar")
                        .WithMany("Bazs")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Xxx.Domain.Aggregates.Foo.Foo", b =>
                {
                    b.OwnsOne("Xxx.Domain.Aggregates.Foo.FullName", "Name", b1 =>
                        {
                            b1.Property<int>("FooId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FirstName");

                            b1.Property<string>("MiddleName");

                            b1.Property<string>("SecondName");

                            b1.HasKey("FooId");

                            b1.ToTable("Foos");

                            b1.HasOne("Xxx.Domain.Aggregates.Foo.Foo")
                                .WithOne("Name")
                                .HasForeignKey("Xxx.Domain.Aggregates.Foo.FullName", "FooId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
