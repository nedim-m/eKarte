using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class BrisanjePoljazaCIjenuidodavanjeistoguLet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OsnovnaCijenaLeta",
                table: "DetaljiLeta");

            migrationBuilder.AddColumn<double>(
                name: "OsnovnaCijenaLeta",
                table: "Let",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OsnovnaCijenaLeta",
                table: "Let");

            migrationBuilder.AddColumn<double>(
                name: "OsnovnaCijenaLeta",
                table: "DetaljiLeta",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
