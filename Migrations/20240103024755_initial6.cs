using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialCourseDefinition",
                table: "SpecialCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialCourseDefinition",
                table: "SpecialCourses");
        }
    }
}
