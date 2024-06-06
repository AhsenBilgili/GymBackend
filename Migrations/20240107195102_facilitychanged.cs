using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class facilitychanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_SpecialCourses_SpecialCourseId",
                table: "Trainers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46cd6370-62c6-4526-bf82-3c022856e737");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aeb1d8f5-48d4-44fb-81b4-1bdca93cfa7c");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialCourseId",
                table: "Trainers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FacilityId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "633bf8a9-d63b-4fce-bbd3-6b03db3300b3", null, "Member", "MEMBER" },
                    { "c7df58c6-22db-4ed3-b278-c5a057c4763c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_FacilityId",
                table: "Trainers",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Facilities_FacilityId",
                table: "Trainers",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_SpecialCourses_SpecialCourseId",
                table: "Trainers",
                column: "SpecialCourseId",
                principalTable: "SpecialCourses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Facilities_FacilityId",
                table: "Trainers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_SpecialCourses_SpecialCourseId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_FacilityId",
                table: "Trainers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "633bf8a9-d63b-4fce-bbd3-6b03db3300b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7df58c6-22db-4ed3-b278-c5a057c4763c");

            migrationBuilder.DropColumn(
                name: "FacilityId",
                table: "Trainers");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialCourseId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46cd6370-62c6-4526-bf82-3c022856e737", null, "Member", "MEMBER" },
                    { "aeb1d8f5-48d4-44fb-81b4-1bdca93cfa7c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_SpecialCourses_SpecialCourseId",
                table: "Trainers",
                column: "SpecialCourseId",
                principalTable: "SpecialCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
