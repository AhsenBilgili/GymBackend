using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class specialcoursesupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4994d608-97e3-40f1-ae18-fd7565673059");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c877cc3-0eaa-48bf-ac62-9f014f096147");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "4994d608-97e3-40f1-ae18-fd7565673059", null, "Admin", "ADMIN" },
                    { "9c877cc3-0eaa-48bf-ac62-9f014f096147", null, "Member", "MEMBER" }
                });
        }
    }
}
