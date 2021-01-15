using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class AddStanicaLinija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StanicaLinija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinijaId = table.Column<int>(nullable: false),
                    StanicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StanicaLinija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StanicaLinija_Linija_LinijaId",
                        column: x => x.LinijaId,
                        principalTable: "Linija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StanicaLinija_Stanica_StanicaId",
                        column: x => x.StanicaId,
                        principalTable: "Stanica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StanicaLinija_LinijaId",
                table: "StanicaLinija",
                column: "LinijaId");

            migrationBuilder.CreateIndex(
                name: "IX_StanicaLinija_StanicaId",
                table: "StanicaLinija",
                column: "StanicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StanicaLinija");
        }
    }
}
