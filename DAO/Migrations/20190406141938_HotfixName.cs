using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations {
    public partial class HotfixName : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropPrimaryKey (
                name: "PK_EntityNames",
                table: "EntityNames");

            migrationBuilder.DeleteData (
                table: "EntityNames",
                keyColumn: "Id",
                keyValue : new Guid ("41155511-fdba-4475-9f9b-68ae315eb9dd"));

            migrationBuilder.DeleteData (
                table: "EntityNames",
                keyColumn: "Id",
                keyValue : new Guid ("7d678b6d-afb6-4e54-b98b-47541bf092a2"));

            migrationBuilder.DeleteData (
                table: "EntityNames",
                keyColumn: "Id",
                keyValue : new Guid ("ac60db70-04d0-43cc-b4ff-6e814c6e9f43"));

            migrationBuilder.DeleteData (
                table: "EntityNames",
                keyColumn: "Id",
                keyValue : new Guid ("d4fd9843-aabb-460f-a8f7-24d428a2f2c8"));

            migrationBuilder.RenameTable (
                name: "EntityNames",
                newName: "Todos");

            migrationBuilder.AddPrimaryKey (
                name: "PK_Todos",
                table: "Todos",
                column: "Id");

            migrationBuilder.InsertData (
                table: "Todos",
                columns : new [] { "Id", "CreatedIn", "Description", "IsComplete" },
                values : new object[, ] { { new Guid ("a5a46d9a-90c8-4f6e-81ec-cb3fdeae25bf"), new DateTime (2019, 4, 6, 11, 19, 38, 242, DateTimeKind.Local).AddTicks (840), "buy a car", false }, { new Guid ("fe44b22a-f888-4a54-be5f-56c45979f43a"), new DateTime (2019, 4, 6, 11, 19, 38, 257, DateTimeKind.Local).AddTicks (1820), "go to the market", false }, { new Guid ("743ea582-3de9-4cea-8709-7a2b983b4a19"), new DateTime (2019, 4, 6, 11, 19, 38, 257, DateTimeKind.Local).AddTicks (1840), "write a magazine", false }, { new Guid ("6382728f-1341-4d02-8b40-2eb5f07e8590"), new DateTime (2019, 4, 6, 11, 19, 38, 257, DateTimeKind.Local).AddTicks (1840), "pay netflix", false }
                });
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropPrimaryKey (
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.DeleteData (
                table: "Todos",
                keyColumn: "Id",
                keyValue : new Guid ("6382728f-1341-4d02-8b40-2eb5f07e8590"));

            migrationBuilder.DeleteData (
                table: "Todos",
                keyColumn: "Id",
                keyValue : new Guid ("743ea582-3de9-4cea-8709-7a2b983b4a19"));

            migrationBuilder.DeleteData (
                table: "Todos",
                keyColumn: "Id",
                keyValue : new Guid ("a5a46d9a-90c8-4f6e-81ec-cb3fdeae25bf"));

            migrationBuilder.DeleteData (
                table: "Todos",
                keyColumn: "Id",
                keyValue : new Guid ("fe44b22a-f888-4a54-be5f-56c45979f43a"));

            migrationBuilder.RenameTable (
                name: "Todos",
                newName: "EntityNames");

            migrationBuilder.AddPrimaryKey (
                name: "PK_EntityNames",
                table: "EntityNames",
                column: "Id");

            migrationBuilder.InsertData (
                table: "EntityNames",
                columns : new [] { "Id", "CreatedIn", "Description", "IsComplete" },
                values : new object[, ] { { new Guid ("d4fd9843-aabb-460f-a8f7-24d428a2f2c8"), new DateTime (2019, 4, 6, 11, 15, 6, 220, DateTimeKind.Local).AddTicks (460), "buy a car", false }, { new Guid ("41155511-fdba-4475-9f9b-68ae315eb9dd"), new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (630), "go to the market", false }, { new Guid ("ac60db70-04d0-43cc-b4ff-6e814c6e9f43"), new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (650), "write a magazine", false }, { new Guid ("7d678b6d-afb6-4e54-b98b-47541bf092a2"), new DateTime (2019, 4, 6, 11, 15, 6, 235, DateTimeKind.Local).AddTicks (660), "pay netflix", false }
                });
        }
    }
}