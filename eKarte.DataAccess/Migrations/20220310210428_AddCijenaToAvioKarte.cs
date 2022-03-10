using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AddCijenaToAvioKarte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AvioKarta",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Cijena",
                table: "AvioKarta",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "AvioKarta");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AvioKarta",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
