using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeForeignKey.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecialCourseTrainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_SpecialCourses_SpecialCourseId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_SpecialCourseId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "SpecialCourseId",
                table: "Trainers");

            migrationBuilder.CreateTable(
                name: "SpecialCourseTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialCourseId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCourseTrainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialCourseTrainers_SpecialCourses_SpecialCourseId",
                        column: x => x.SpecialCourseId,
                        principalTable: "SpecialCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialCourseTrainers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCourseTrainers_SpecialCourseId",
                table: "SpecialCourseTrainers",
                column: "SpecialCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCourseTrainers_TrainerId",
                table: "SpecialCourseTrainers",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialCourseTrainers");

            migrationBuilder.AddColumn<int>(
                name: "SpecialCourseId",
                table: "Trainers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_SpecialCourseId",
                table: "Trainers",
                column: "SpecialCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_SpecialCourses_SpecialCourseId",
                table: "Trainers",
                column: "SpecialCourseId",
                principalTable: "SpecialCourses",
                principalColumn: "Id");
        }
    }
}
