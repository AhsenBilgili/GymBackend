using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialCourses_SpecialCourses_SpecialCourseId",
                table: "SpecialCourses");

            migrationBuilder.DropIndex(
                name: "IX_SpecialCourses_SpecialCourseId",
                table: "SpecialCourses");

            migrationBuilder.DropColumn(
                name: "SpecialCourseId",
                table: "SpecialCourses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialCourseId",
                table: "SpecialCourses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCourses_SpecialCourseId",
                table: "SpecialCourses",
                column: "SpecialCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialCourses_SpecialCourses_SpecialCourseId",
                table: "SpecialCourses",
                column: "SpecialCourseId",
                principalTable: "SpecialCourses",
                principalColumn: "Id");
        }
    }
}
