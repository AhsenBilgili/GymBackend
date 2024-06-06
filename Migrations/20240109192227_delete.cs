using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da9a0305-5dce-4a32-a74f-cbb866bdba7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1dc9601-5996-46f5-a98c-6ed4458e05d2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a8e7125-41a8-446f-a8ec-8d56d7ab9acb", null, "Admin", "ADMIN" },
                    { "bfaed647-48d8-4b18-89e5-f8d1f9ae554c", null, "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a8e7125-41a8-446f-a8ec-8d56d7ab9acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfaed647-48d8-4b18-89e5-f8d1f9ae554c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "da9a0305-5dce-4a32-a74f-cbb866bdba7a", null, "Admin", "ADMIN" },
                    { "e1dc9601-5996-46f5-a98c-6ed4458e05d2", null, "Member", "MEMBER" }
                });
        }
    }
}
