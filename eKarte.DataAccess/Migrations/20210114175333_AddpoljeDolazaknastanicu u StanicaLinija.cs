using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AddpoljeDolazaknastanicuuStanicaLinija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DolazakaVrijeme",
                table: "StanicaLinija",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DolazakaVrijeme",
                table: "StanicaLinija");
        }
    }
}
