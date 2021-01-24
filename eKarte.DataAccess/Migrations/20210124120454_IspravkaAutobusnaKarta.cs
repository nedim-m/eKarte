using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class IspravkaAutobusnaKarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutobusnaKarta_Linija_LinijaId",
                table: "AutobusnaKarta");

            migrationBuilder.DropIndex(
                name: "IX_AutobusnaKarta_LinijaId",
                table: "AutobusnaKarta");

            migrationBuilder.DropColumn(
                name: "LinijaId",
                table: "AutobusnaKarta");

            migrationBuilder.AddColumn<int>(
                name: "StanicaLinijaId",
                table: "AutobusnaKarta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AutobusnaKarta_StanicaLinijaId",
                table: "AutobusnaKarta",
                column: "StanicaLinijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutobusnaKarta_StanicaLinija_StanicaLinijaId",
                table: "AutobusnaKarta",
                column: "StanicaLinijaId",
                principalTable: "StanicaLinija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutobusnaKarta_StanicaLinija_StanicaLinijaId",
                table: "AutobusnaKarta");

            migrationBuilder.DropIndex(
                name: "IX_AutobusnaKarta_StanicaLinijaId",
                table: "AutobusnaKarta");

            migrationBuilder.DropColumn(
                name: "StanicaLinijaId",
                table: "AutobusnaKarta");

            migrationBuilder.AddColumn<int>(
                name: "LinijaId",
                table: "AutobusnaKarta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AutobusnaKarta_LinijaId",
                table: "AutobusnaKarta",
                column: "LinijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutobusnaKarta_Linija_LinijaId",
                table: "AutobusnaKarta",
                column: "LinijaId",
                principalTable: "Linija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
