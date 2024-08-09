using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.DAL.Migrations
{
    public partial class entity_columns_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "TaskUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TaskUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "TaskUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TaskUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TaskUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "TaskUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TaskUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TaskUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TaskUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TaskUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TaskUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PhoneNumber",
                table: "TaskUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
