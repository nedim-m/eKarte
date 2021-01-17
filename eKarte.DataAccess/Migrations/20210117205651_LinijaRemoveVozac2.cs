using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class LinijaRemoveVozac2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Linija_Osoblje_Vozac2Id",
                table: "Linija");

            migrationBuilder.DropIndex(
                name: "IX_Linija_Vozac2Id",
                table: "Linija");

            migrationBuilder.DropColumn(
                name: "Vozac2Id",
                table: "Linija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Vozac2Id",
                table: "Linija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Linija_Vozac2Id",
                table: "Linija",
                column: "Vozac2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Linija_Osoblje_Vozac2Id",
                table: "Linija",
                column: "Vozac2Id",
                principalTable: "Osoblje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
