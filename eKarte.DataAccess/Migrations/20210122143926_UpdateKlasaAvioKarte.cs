using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class UpdateKlasaAvioKarte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpisPogodnosti",
                table: "KlasaAvioKarte");

            migrationBuilder.AddColumn<string>(
                name: "Hrana",
                table: "KlasaAvioKarte",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MjestoDoProzora",
                table: "KlasaAvioKarte",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PortZaPunjenjeUredjaja",
                table: "KlasaAvioKarte",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosebnoSjediste",
                table: "KlasaAvioKarte",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WiFi",
                table: "KlasaAvioKarte",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hrana",
                table: "KlasaAvioKarte");

            migrationBuilder.DropColumn(
                name: "MjestoDoProzora",
                table: "KlasaAvioKarte");

            migrationBuilder.DropColumn(
                name: "PortZaPunjenjeUredjaja",
                table: "KlasaAvioKarte");

            migrationBuilder.DropColumn(
                name: "PosebnoSjediste",
                table: "KlasaAvioKarte");

            migrationBuilder.DropColumn(
                name: "WiFi",
                table: "KlasaAvioKarte");

            migrationBuilder.AddColumn<string>(
                name: "OpisPogodnosti",
                table: "KlasaAvioKarte",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
