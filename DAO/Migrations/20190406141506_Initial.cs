using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations {
    public partial class Initial : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable (
                name: "EntityNames",
                columns : table => new {
                    Id = table.Column<Guid> (nullable: false),
                        Description = table.Column<string> (nullable: true),
                        IsComplete = table.Column<bool> (nullable: false),
                        CreatedIn = table.Column<DateTime> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_EntityNames", x => x.Id);
                });

            migrationBuilder.InsertData (
                table: "EntityNames",
                columns : new [] { "Id", "CreatedIn", "Description", "IsComplete" },
                values : new object[, ] { { new Guid ("d4fd9843-aabb-460f-a8f7-24d428a2f2c8"), new DateTime (2019, 4, 6, 11, 15, 6, 220, DateTimeKind.Local).AddTicks (460), "buy a car", false }, { new Guid ("41155511-fdba-4475-9f9b-68ae315eb9dd"), new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (630), "go to the market", false }, { new Guid ("ac60db70-04d0-43cc-b4ff-6e814c6e9f43"), new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (650), "write a magazine", false }, { new Guid ("7d678b6d-afb6-4e54-b98b-47541bf092a2"), new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (660), "pay netflix", false }
                });
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "EntityNames");
        }
    }
}