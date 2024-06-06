using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class facilitiesupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "246b3ada-c933-49c9-a656-b6e046d7cfc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d438e4a-d4d2-48de-8221-07d06c174e2e");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4994d608-97e3-40f1-ae18-fd7565673059", null, "Admin", "ADMIN" },
                    { "9c877cc3-0eaa-48bf-ac62-9f014f096147", null, "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4994d608-97e3-40f1-ae18-fd7565673059");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c877cc3-0eaa-48bf-ac62-9f014f096147");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Facilities");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "246b3ada-c933-49c9-a656-b6e046d7cfc6", null, "Member", "MEMBER" },
                    { "2d438e4a-d4d2-48de-8221-07d06c174e2e", null, "Admin", "ADMIN" }
                });
        }
    }
}
