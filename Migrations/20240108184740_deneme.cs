using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b7ad255-f7dc-4466-b70d-60dfd5db0f84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20fb853-da6d-4265-8b6a-b020b591cea5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c3b6c3e-e090-4e41-9cd8-ee162dc7372c", null, "Member", "MEMBER" },
                    { "b84a0254-8d0a-4311-974d-98c0f7420b8c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c3b6c3e-e090-4e41-9cd8-ee162dc7372c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b84a0254-8d0a-4311-974d-98c0f7420b8c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b7ad255-f7dc-4466-b70d-60dfd5db0f84", null, "Admin", "ADMIN" },
                    { "f20fb853-da6d-4265-8b6a-b020b591cea5", null, "Member", "MEMBER" }
                });
        }
    }
}
