using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class phoneadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a8e7125-41a8-446f-a8ec-8d56d7ab9acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfaed647-48d8-4b18-89e5-f8d1f9ae554c");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "DaySchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "DaySchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.CreateTable(
                name: "HomePageCards",
                columns: table => new
                {
                    HomePageCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomePageCardContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePageCardImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageCards", x => x.HomePageCardId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9135e7c3-b64c-4bfb-8623-bae503bc7525", null, "Member", "MEMBER" },
                    { "f3b8f788-dc22-4429-a15d-bf0c1a16aa62", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePageCards");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9135e7c3-b64c-4bfb-8623-bae503bc7525");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b8f788-dc22-4429-a15d-bf0c1a16aa62");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Facilities");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "DaySchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "DaySchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a8e7125-41a8-446f-a8ec-8d56d7ab9acb", null, "Admin", "ADMIN" },
                    { "bfaed647-48d8-4b18-89e5-f8d1f9ae554c", null, "Member", "MEMBER" }
                });
        }
    }
}
