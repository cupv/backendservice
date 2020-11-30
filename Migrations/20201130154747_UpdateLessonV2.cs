using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateLessonV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ Place_Lession_LessionId",
                table: " Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Lession_Course_CourseId",
                table: "Lession");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Lession_LessonId",
                table: "Quiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lession",
                table: "Lession");

            migrationBuilder.RenameTable(
                name: "Lession",
                newName: "Lesson");

            migrationBuilder.RenameIndex(
                name: "IX_Lession_CourseId",
                table: "Lesson",
                newName: "IX_Lesson_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ Place_Lesson_LessionId",
                table: " Place",
                column: "LessionId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Course_CourseId",
                table: "Lesson",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Lesson_LessonId",
                table: "Quiz",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ Place_Lesson_LessionId",
                table: " Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Course_CourseId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Lesson_LessonId",
                table: "Quiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lession");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_CourseId",
                table: "Lession",
                newName: "IX_Lession_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lession",
                table: "Lession",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ Place_Lession_LessionId",
                table: " Place",
                column: "LessionId",
                principalTable: "Lession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lession_Course_CourseId",
                table: "Lession",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Lession_LessonId",
                table: "Quiz",
                column: "LessonId",
                principalTable: "Lession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
