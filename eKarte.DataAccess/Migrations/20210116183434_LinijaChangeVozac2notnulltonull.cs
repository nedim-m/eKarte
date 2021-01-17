using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class LinijaChangeVozac2notnulltonull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Linija_Osoblje_Vozac2Id",
                table: "Linija");

            migrationBuilder.AlterColumn<int>(
                name: "Vozac2Id",
                table: "Linija",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Linija_Osoblje_Vozac2Id",
                table: "Linija",
                column: "Vozac2Id",
                principalTable: "Osoblje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Linija_Osoblje_Vozac2Id",
                table: "Linija");

            migrationBuilder.AlterColumn<int>(
                name: "Vozac2Id",
                table: "Linija",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Linija_Osoblje_Vozac2Id",
                table: "Linija",
                column: "Vozac2Id",
                principalTable: "Osoblje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
