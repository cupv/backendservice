using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class mtm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SVs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SVs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KHSVs",
                columns: table => new
                {
                    KHId = table.Column<Guid>(nullable: false),
                    SVId = table.Column<Guid>(nullable: false)
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
                name: "IX_KHSVs_KHId",
                table: "KHSVs",
                column: "KHId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KHSVs");

            migrationBuilder.DropTable(
                name: "KHs");

            migrationBuilder.DropTable(
                name: "SVs");
        }
    }
}
