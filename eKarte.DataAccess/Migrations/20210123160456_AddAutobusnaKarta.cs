using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AddAutobusnaKarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutobusnaKarta",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    LinijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutobusnaKarta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutobusnaKarta_Linija_LinijaId",
                        column: x => x.LinijaId,
                        principalTable: "Linija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutobusnaKarta_LinijaId",
                table: "AutobusnaKarta",
                column: "LinijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutobusnaKarta");
        }
    }
}
