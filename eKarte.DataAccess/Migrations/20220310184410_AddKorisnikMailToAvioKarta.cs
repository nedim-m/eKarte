using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AddKorisnikMailToAvioKarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorsnikMail",
                table: "AvioKarta");

            migrationBuilder.AddColumn<string>(
                name: "KorisnikMail",
                table: "AvioKarta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnikMail",
                table: "AvioKarta");

            migrationBuilder.AddColumn<string>(
                name: "KorsnikMail",
                table: "AvioKarta",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
