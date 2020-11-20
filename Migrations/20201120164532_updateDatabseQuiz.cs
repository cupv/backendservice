using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class updateDatabseQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Quiz");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Quiz",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Quiz");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
