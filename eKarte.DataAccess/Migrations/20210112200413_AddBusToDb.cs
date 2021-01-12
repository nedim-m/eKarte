using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AddBusToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Proizvodjac",
                table: "Avion",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Avion",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Avion",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Proizvodjac = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false),
                    TipBusaId = table.Column<int>(nullable: false),
                    KompanijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bus_Kompanija_KompanijaId",
                        column: x => x.KompanijaId,
                        principalTable: "Kompanija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bus_TipBusa_TipBusaId",
                        column: x => x.TipBusaId,
                        principalTable: "TipBusa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_KompanijaId",
                table: "Bus",
                column: "KompanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_TipBusaId",
                table: "Bus",
                column: "TipBusaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.AlterColumn<string>(
                name: "Proizvodjac",
                table: "Avion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Avion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Avion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
