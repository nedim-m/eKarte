using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class updateAvionaAerodrom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradId",
                table: "Aerodrom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aerodrom_GradId",
                table: "Aerodrom",
                column: "GradId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aerodrom_Grad_GradId",
                table: "Aerodrom",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aerodrom_Grad_GradId",
                table: "Aerodrom");

            migrationBuilder.DropIndex(
                name: "IX_Aerodrom_GradId",
                table: "Aerodrom");

            migrationBuilder.DropColumn(
                name: "GradId",
                table: "Aerodrom");
        }
    }
}
