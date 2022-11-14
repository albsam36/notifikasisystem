using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Form.Migrations
{
    public partial class InitialCreate123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departement",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "alasan",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "file",
                table: "Employees",
                newName: "No_Kontak");

            migrationBuilder.RenameColumn(
                name: "confirmation",
                table: "Employees",
                newName: "NamaVendor");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Employees",
                newName: "EventName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Periode",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Periode",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "No_Kontak",
                table: "Employees",
                newName: "file");

            migrationBuilder.RenameColumn(
                name: "NamaVendor",
                table: "Employees",
                newName: "confirmation");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Employees",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Departement",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "alasan",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
