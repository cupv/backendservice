using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class updateTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Teams",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ClassId",
                table: "Teams",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Class_ClassId",
                table: "Teams",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Class_ClassId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ClassId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Teams");
        }
    }
}
