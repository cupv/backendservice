using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentGradeId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentGradeId",
                table: "Students",
                column: "CurrentGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grades_CurrentGradeId",
                table: "Students",
                column: "CurrentGradeId",
                principalTable: "Grades",
                principalColumn: "GradeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grades_CurrentGradeId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Students_CurrentGradeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentGradeId",
                table: "Students");
        }
    }
}
