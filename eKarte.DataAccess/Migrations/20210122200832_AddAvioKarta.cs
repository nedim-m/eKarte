using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AddAvioKarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WiFi",
                table: "KlasaAvioKarte",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PosebnoSjediste",
                table: "KlasaAvioKarte",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PortZaPunjenjeUredjaja",
                table: "KlasaAvioKarte",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MjestoDoProzora",
                table: "KlasaAvioKarte",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hrana",
                table: "KlasaAvioKarte",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AvioKarta",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    LetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvioKarta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvioKarta_Let_LetId",
                        column: x => x.LetId,
                        principalTable: "Let",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvioKarta_LetId",
                table: "AvioKarta",
                column: "LetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvioKarta");

            migrationBuilder.AlterColumn<string>(
                name: "WiFi",
                table: "KlasaAvioKarte",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PosebnoSjediste",
                table: "KlasaAvioKarte",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PortZaPunjenjeUredjaja",
                table: "KlasaAvioKarte",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MjestoDoProzora",
                table: "KlasaAvioKarte",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Hrana",
                table: "KlasaAvioKarte",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
