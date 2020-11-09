using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class EditEnity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Lessions");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: "Lessions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: " Places");

            migrationBuilder.DropColumn(
                name: "ModifiedDated",
                table: " Places");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Lessions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Lessions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Class",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Class",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Campaigns",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Campaigns",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: " Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: " Places",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Lessions");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Lessions");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Created",
                table: " Places");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: " Places");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Teams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: "Teams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Lessions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: "Lessions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: "Grades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Class",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: "Class",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Campaigns",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: "Campaigns",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: " Places",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDated",
                table: " Places",
                type: "datetime2",
                nullable: true);
        }
    }
}
