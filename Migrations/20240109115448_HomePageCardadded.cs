using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class HomePageCardadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c3b6c3e-e090-4e41-9cd8-ee162dc7372c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b84a0254-8d0a-4311-974d-98c0f7420b8c");

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
                    { "1eeda9cd-034e-49ee-827b-9c820142c4ea", null, "Admin", "ADMIN" },
                    { "c3400315-cf65-4089-84f9-86fb6963379d", null, "Member", "MEMBER" }
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
                    { "2c3b6c3e-e090-4e41-9cd8-ee162dc7372c", null, "Member", "MEMBER" },
                    { "b84a0254-8d0a-4311-974d-98c0f7420b8c", null, "Admin", "ADMIN" }
                });
        }
    }
}
