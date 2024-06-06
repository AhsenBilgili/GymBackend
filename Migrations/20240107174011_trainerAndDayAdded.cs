using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class trainerAndDayAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1037011f-84a1-4610-a66a-3e2b9e961829");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f140e7b-e848-4509-a9a4-28a24b06129a");

            migrationBuilder.AddColumn<string>(
                name: "SpecialCourseCondition",
                table: "SpecialCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialCourseImgUrl",
                table: "SpecialCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06d54458-9520-4ef5-9fe4-98b301460505", null, "Member", "MEMBER" },
                    { "101c6df7-2c11-494c-b50d-97bf47d338b6", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06d54458-9520-4ef5-9fe4-98b301460505");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "101c6df7-2c11-494c-b50d-97bf47d338b6");

            migrationBuilder.DropColumn(
                name: "SpecialCourseCondition",
                table: "SpecialCourses");

            migrationBuilder.DropColumn(
                name: "SpecialCourseImgUrl",
                table: "SpecialCourses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1037011f-84a1-4610-a66a-3e2b9e961829", null, "Member", "MEMBER" },
                    { "6f140e7b-e848-4509-a9a4-28a24b06129a", null, "Admin", "ADMIN" }
                });
        }
    }
}
