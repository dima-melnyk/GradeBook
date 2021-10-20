using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeBook.DataAccess.Migrations
{
    public partial class editGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Lessons_LessonId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Pupils_PupilId",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "PupilId",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Lessons_LessonId",
                table: "Grades",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Pupils_PupilId",
                table: "Grades",
                column: "PupilId",
                principalTable: "Pupils",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Lessons_LessonId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Pupils_PupilId",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "PupilId",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Lessons_LessonId",
                table: "Grades",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Pupils_PupilId",
                table: "Grades",
                column: "PupilId",
                principalTable: "Pupils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
