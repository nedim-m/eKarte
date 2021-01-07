using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AvionLetKompanijaDetalji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Proizvodjac = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kompanija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Let",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumLeta = table.Column<DateTime>(nullable: false),
                    VrijemeLeta = table.Column<string>(nullable: true),
                    AerodromDoId = table.Column<int>(nullable: false),
                    AerodromOdId = table.Column<int>(nullable: false),
                    AvionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Let", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Let_Aerodrom_AerodromDoId",
                        column: x => x.AerodromDoId,
                        principalTable: "Aerodrom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Let_Aerodrom_AerodromOdId",
                        column: x => x.AerodromOdId,
                        principalTable: "Aerodrom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Let_Avion_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Avion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DetaljiLeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsobljeId = table.Column<int>(nullable: false),
                    LetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaljiLeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetaljiLeta_Let_LetId",
                        column: x => x.LetId,
                        principalTable: "Let",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaljiLeta_Osoblje_OsobljeId",
                        column: x => x.OsobljeId,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiLeta_LetId",
                table: "DetaljiLeta",
                column: "LetId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiLeta_OsobljeId",
                table: "DetaljiLeta",
                column: "OsobljeId");

            migrationBuilder.CreateIndex(
                name: "IX_Let_AerodromDoId",
                table: "Let",
                column: "AerodromDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Let_AerodromOdId",
                table: "Let",
                column: "AerodromOdId");

            migrationBuilder.CreateIndex(
                name: "IX_Let_AvionId",
                table: "Let",
                column: "AvionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaljiLeta");

            migrationBuilder.DropTable(
                name: "Kompanija");

            migrationBuilder.DropTable(
                name: "Let");

            migrationBuilder.DropTable(
                name: "Avion");
        }
    }
}
