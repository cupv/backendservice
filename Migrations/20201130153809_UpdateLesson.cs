using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Lession_LessionId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_LessionId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "LessionId",
                table: "Quiz");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "Quiz",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_LessonId",
                table: "Quiz",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Lession_LessonId",
                table: "Quiz",
                column: "LessonId",
                principalTable: "Lession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Lession_LessonId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_LessonId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Quiz");

            migrationBuilder.AddColumn<Guid>(
                name: "LessionId",
                table: "Quiz",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_LessionId",
                table: "Quiz",
                column: "LessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Lession_LessionId",
                table: "Quiz",
                column: "LessionId",
                principalTable: "Lession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
