using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class UpdateAviona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KompanijaId",
                table: "Avion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avion_KompanijaId",
                table: "Avion",
                column: "KompanijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avion_Kompanija_KompanijaId",
                table: "Avion",
                column: "KompanijaId",
                principalTable: "Kompanija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avion_Kompanija_KompanijaId",
                table: "Avion");

            migrationBuilder.DropIndex(
                name: "IX_Avion_KompanijaId",
                table: "Avion");

            migrationBuilder.DropColumn(
                name: "KompanijaId",
                table: "Avion");
        }
    }
}
