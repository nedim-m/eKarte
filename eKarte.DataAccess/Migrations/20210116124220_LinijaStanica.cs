using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class LinijaStanica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StanicaLinija_Stanica_StanicaId",
                table: "StanicaLinija");

            migrationBuilder.DropIndex(
                name: "IX_StanicaLinija_StanicaId",
                table: "StanicaLinija");

            migrationBuilder.DropColumn(
                name: "StanicaId",
                table: "StanicaLinija");

            migrationBuilder.AddColumn<DateTime>(
                name: "PolazakVrijeme",
                table: "StanicaLinija",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StanicaOdredisteId",
                table: "StanicaLinija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StanicaPolazisteId",
                table: "StanicaLinija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StanicaLinija_StanicaOdredisteId",
                table: "StanicaLinija",
                column: "StanicaOdredisteId");

            migrationBuilder.CreateIndex(
                name: "IX_StanicaLinija_StanicaPolazisteId",
                table: "StanicaLinija",
                column: "StanicaPolazisteId");

            migrationBuilder.AddForeignKey(
                name: "FK_StanicaLinija_Stanica_StanicaOdredisteId",
                table: "StanicaLinija",
                column: "StanicaOdredisteId",
                principalTable: "Stanica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StanicaLinija_Stanica_StanicaPolazisteId",
                table: "StanicaLinija",
                column: "StanicaPolazisteId",
                principalTable: "Stanica",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StanicaLinija_Stanica_StanicaOdredisteId",
                table: "StanicaLinija");

            migrationBuilder.DropForeignKey(
                name: "FK_StanicaLinija_Stanica_StanicaPolazisteId",
                table: "StanicaLinija");

            migrationBuilder.DropIndex(
                name: "IX_StanicaLinija_StanicaOdredisteId",
                table: "StanicaLinija");

            migrationBuilder.DropIndex(
                name: "IX_StanicaLinija_StanicaPolazisteId",
                table: "StanicaLinija");

            migrationBuilder.DropColumn(
                name: "PolazakVrijeme",
                table: "StanicaLinija");

            migrationBuilder.DropColumn(
                name: "StanicaOdredisteId",
                table: "StanicaLinija");

            migrationBuilder.DropColumn(
                name: "StanicaPolazisteId",
                table: "StanicaLinija");

            migrationBuilder.AddColumn<int>(
                name: "StanicaId",
                table: "StanicaLinija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StanicaLinija_StanicaId",
                table: "StanicaLinija",
                column: "StanicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_StanicaLinija_Stanica_StanicaId",
                table: "StanicaLinija",
                column: "StanicaId",
                principalTable: "Stanica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
