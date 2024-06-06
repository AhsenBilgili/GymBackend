using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class failities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89cc1ea2-d6ce-4c48-98c6-bb82fa66f814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a468d3-0194-4750-b979-f6fd96df7673");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b83df696-b7df-4b01-ab6c-0baff45b02cc", null, "Member", "MEMBER" },
                    { "bb71af09-926a-44ee-80a1-38754a66e190", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b83df696-b7df-4b01-ab6c-0baff45b02cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb71af09-926a-44ee-80a1-38754a66e190");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89cc1ea2-d6ce-4c48-98c6-bb82fa66f814", null, "Member", "MEMBER" },
                    { "b3a468d3-0194-4750-b979-f6fd96df7673", null, "Admin", "ADMIN" }
                });
        }
    }
}
