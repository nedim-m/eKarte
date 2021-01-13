using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AddLinijaToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vozac1Id = table.Column<int>(nullable: false),
                    Vozac2Id = table.Column<int>(nullable: false),
                    KondukterId = table.Column<int>(nullable: false),
                    BusId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    OsnovnaCijenaLinije = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linija_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Linija_Osoblje_KondukterId",
                        column: x => x.KondukterId,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Linija_Osoblje_Vozac1Id",
                        column: x => x.Vozac1Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Linija_Osoblje_Vozac2Id",
                        column: x => x.Vozac2Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Linija_BusId",
                table: "Linija",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_KondukterId",
                table: "Linija",
                column: "KondukterId");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_Vozac1Id",
                table: "Linija",
                column: "Vozac1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_Vozac2Id",
                table: "Linija",
                column: "Vozac2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linija");
        }
    }
}
