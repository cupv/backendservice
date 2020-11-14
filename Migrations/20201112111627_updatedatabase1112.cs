using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class updatedatabase1112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Class_ClassId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "KHSVs");

            migrationBuilder.DropTable(
                name: "KHs");

            migrationBuilder.DropTable(
                name: "SVs");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClassId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "ClassUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassUsers", x => new { x.UserId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_ClassUsers_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassUsers_ClassId",
                table: "ClassUsers",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KHs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SVs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SVs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KHSVs",
                columns: table => new
                {
                    SVId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KHId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHSVs", x => new { x.SVId, x.KHId });
                    table.ForeignKey(
                        name: "FK_KHSVs_KHs_KHId",
                        column: x => x.KHId,
                        principalTable: "KHs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KHSVs_SVs_SVId",
                        column: x => x.SVId,
                        principalTable: "SVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassId",
                table: "Users",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_KHSVs_KHId",
                table: "KHSVs",
                column: "KHId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Class_ClassId",
                table: "Users",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
