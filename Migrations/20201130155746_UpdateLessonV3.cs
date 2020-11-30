using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateLessonV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Lesson_LessonId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_LessonId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Quiz");

            migrationBuilder.AddColumn<Guid>(
                name: "QuizId",
                table: "Lesson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Lesson",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_QuizId",
                table: "Lesson",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Quiz_QuizId",
                table: "Lesson",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Quiz_QuizId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_QuizId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Lesson");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "Quiz",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_LessonId",
                table: "Quiz",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Lesson_LessonId",
                table: "Quiz",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
