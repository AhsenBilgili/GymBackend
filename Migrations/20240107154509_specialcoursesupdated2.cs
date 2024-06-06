using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class specialcoursesupdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e263bd2-d4da-4410-9596-2255c73b3d5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faef00d6-34b3-4c98-b57a-c2e326e33a8a");

            migrationBuilder.DropColumn(
                name: "SpecialCourseImageUrl",
                table: "SpecialCourses");

            migrationBuilder.DropColumn(
                name: "SpecialCourseRules",
                table: "SpecialCourses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89cc1ea2-d6ce-4c48-98c6-bb82fa66f814", null, "Member", "MEMBER" },
                    { "b3a468d3-0194-4750-b979-f6fd96df7673", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89cc1ea2-d6ce-4c48-98c6-bb82fa66f814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a468d3-0194-4750-b979-f6fd96df7673");

            migrationBuilder.AddColumn<string>(
                name: "SpecialCourseImageUrl",
                table: "SpecialCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialCourseRules",
                table: "SpecialCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e263bd2-d4da-4410-9596-2255c73b3d5d", null, "Admin", "ADMIN" },
                    { "faef00d6-34b3-4c98-b57a-c2e326e33a8a", null, "Member", "MEMBER" }
                });
        }
    }
}
