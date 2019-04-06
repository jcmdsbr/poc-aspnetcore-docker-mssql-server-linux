// <auto-generated />
using System;
using DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAO.Migrations {
    [DbContext (typeof (Context))]
    [Migration ("20190406141506_Initial")]
    partial class Initial {
        protected override void BuildTargetModel (ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation ("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation ("Relational:MaxIdentifierLength", 128)
                .HasAnnotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity ("DAO.Models.Todo", b => {
                b.Property<Guid> ("Id")
                    .ValueGeneratedOnAdd ();

                b.Property<DateTime> ("CreatedIn");

                b.Property<string> ("Description");

                b.Property<bool> ("IsComplete");

                b.HasKey ("Id");

                b.ToTable ("EntityNames");

                b.HasData (
                    new {
                        Id = new Guid ("d4fd9843-aabb-460f-a8f7-24d428a2f2c8"),
                            CreatedIn = new DateTime (2019, 4, 6, 11, 15, 6, 220, DateTimeKind.Local).AddTicks (460),
                            Description = "buy a car",
                            IsComplete = false
                    },
                    new {
                        Id = new Guid ("41155511-fdba-4475-9f9b-68ae315eb9dd"),
                            CreatedIn = new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (630),
                            Description = "go to the market",
                            IsComplete = false
                    },
                    new {
                        Id = new Guid ("ac60db70-04d0-43cc-b4ff-6e814c6e9f43"),
                            CreatedIn = new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (650),
                            Description = "write a magazine",
                            IsComplete = false
                    },
                    new {
                        Id = new Guid ("7d678b6d-afb6-4e54-b98b-47541bf092a2"),
                            CreatedIn = new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (660),
                            Description = "pay netflix",
                            IsComplete = false
                    });
            });
#pragma warning restore 612, 618
        }
    }
}