using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class HomePageCardadded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eeda9cd-034e-49ee-827b-9c820142c4ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3400315-cf65-4089-84f9-86fb6963379d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "da9a0305-5dce-4a32-a74f-cbb866bdba7a", null, "Admin", "ADMIN" },
                    { "e1dc9601-5996-46f5-a98c-6ed4458e05d2", null, "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1eeda9cd-034e-49ee-827b-9c820142c4ea", null, "Admin", "ADMIN" },
                    { "c3400315-cf65-4089-84f9-86fb6963379d", null, "Member", "MEMBER" }
                });
        }
    }
}
