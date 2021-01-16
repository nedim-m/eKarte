using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class EditLinija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DolazakaVrijeme",
                table: "StanicaLinija");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Linija");

            migrationBuilder.AddColumn<double>(
                name: "Cijena",
                table: "StanicaLinija",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DolazakVrijeme",
                table: "StanicaLinija",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DolazakVrijeme",
                table: "Linija",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PolazakVrijeme",
                table: "Linija",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StanicaPocetnaId",
                table: "Linija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StanicaZadnjaId",
                table: "Linija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Linija_StanicaPocetnaId",
                table: "Linija",
                column: "StanicaPocetnaId");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_StanicaZadnjaId",
                table: "Linija",
                column: "StanicaZadnjaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Linija_Stanica_StanicaPocetnaId",
                table: "Linija",
                column: "StanicaPocetnaId",
                principalTable: "Stanica",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Linija_Stanica_StanicaZadnjaId",
                table: "Linija",
                column: "StanicaZadnjaId",
                principalTable: "Stanica",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Linija_Stanica_StanicaPocetnaId",
                table: "Linija");

            migrationBuilder.DropForeignKey(
                name: "FK_Linija_Stanica_StanicaZadnjaId",
                table: "Linija");

            migrationBuilder.DropIndex(
                name: "IX_Linija_StanicaPocetnaId",
                table: "Linija");

            migrationBuilder.DropIndex(
                name: "IX_Linija_StanicaZadnjaId",
                table: "Linija");

            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "StanicaLinija");

            migrationBuilder.DropColumn(
                name: "DolazakVrijeme",
                table: "StanicaLinija");

            migrationBuilder.DropColumn(
                name: "DolazakVrijeme",
                table: "Linija");

            migrationBuilder.DropColumn(
                name: "PolazakVrijeme",
                table: "Linija");

            migrationBuilder.DropColumn(
                name: "StanicaPocetnaId",
                table: "Linija");

            migrationBuilder.DropColumn(
                name: "StanicaZadnjaId",
                table: "Linija");

            migrationBuilder.AddColumn<DateTime>(
                name: "DolazakaVrijeme",
                table: "StanicaLinija",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Linija",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
