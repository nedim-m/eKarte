using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarte.DataAccess.Migrations
{
    public partial class Pocetna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KlasaAvioKarte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Hrana = table.Column<string>(nullable: false),
                    WiFi = table.Column<string>(nullable: false),
                    PosebnoSjediste = table.Column<string>(nullable: false),
                    PortZaPunjenjeUredjaja = table.Column<string>(nullable: false),
                    MjestoDoProzora = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlasaAvioKarte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kompanija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipBusa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipBusa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipKarte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKarte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipOsoblja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Oznaka = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipOsoblja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaKarte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Popust = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaKarte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Proizvodjac = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false),
                    KompanijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avion_Kompanija_KompanijaId",
                        column: x => x.KompanijaId,
                        principalTable: "Kompanija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Proizvodjac = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false),
                    TipBusaId = table.Column<int>(nullable: false),
                    KompanijaId = table.Column<int>(nullable: false),
                    RegistracijskaOznaka = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bus_Kompanija_KompanijaId",
                        column: x => x.KompanijaId,
                        principalTable: "Kompanija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bus_TipBusa_TipBusaId",
                        column: x => x.TipBusaId,
                        principalTable: "TipBusa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Osoblje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefon = table.Column<string>(nullable: false),
                    JMBG = table.Column<string>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    DatumZaposljenja = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    TipOsobljaId = table.Column<int>(nullable: false),
                    SpolId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoblje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osoblje_Spol_SpolId",
                        column: x => x.SpolId,
                        principalTable: "Spol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Osoblje_TipOsoblja_TipOsobljaId",
                        column: x => x.TipOsobljaId,
                        principalTable: "TipOsoblja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aerodrom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Sifra = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerodrom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aerodrom_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stanica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: false),
                    Telefon = table.Column<string>(nullable: false),
                    GradId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stanica_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Let",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumLeta = table.Column<DateTime>(nullable: false),
                    VrijemeLeta = table.Column<string>(nullable: false),
                    AerodromDoId = table.Column<int>(nullable: false),
                    AerodromOdId = table.Column<int>(nullable: false),
                    AvionId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    OsnovnaCijenaLeta = table.Column<double>(nullable: false),
                    BrojPosadeNaletu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Let", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Let_Aerodrom_AerodromDoId",
                        column: x => x.AerodromDoId,
                        principalTable: "Aerodrom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Let_Aerodrom_AerodromOdId",
                        column: x => x.AerodromOdId,
                        principalTable: "Aerodrom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Let_Avion_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Avion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Linija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vozac1Id = table.Column<int>(nullable: false),
                    KondukterId = table.Column<int>(nullable: false),
                    BusId = table.Column<int>(nullable: false),
                    StanicaPocetnaId = table.Column<int>(nullable: false),
                    StanicaZadnjaId = table.Column<int>(nullable: false),
                    PolazakVrijeme = table.Column<DateTime>(nullable: false),
                    DolazakVrijeme = table.Column<DateTime>(nullable: false),
                    OsnovnaCijenaLinije = table.Column<double>(nullable: false),
                    Svakodnevna = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linija_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Linija_Osoblje_KondukterId",
                        column: x => x.KondukterId,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Linija_Stanica_StanicaPocetnaId",
                        column: x => x.StanicaPocetnaId,
                        principalTable: "Stanica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Linija_Stanica_StanicaZadnjaId",
                        column: x => x.StanicaZadnjaId,
                        principalTable: "Stanica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Linija_Osoblje_Vozac1Id",
                        column: x => x.Vozac1Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AvioKarta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    LetId = table.Column<int>(nullable: false),
                    KorisnikMail = table.Column<string>(nullable: true),
                    KonacnaCijena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvioKarta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvioKarta_Let_LetId",
                        column: x => x.LetId,
                        principalTable: "Let",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetaljiLeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsobljeId = table.Column<int>(nullable: false),
                    LetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaljiLeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetaljiLeta_Let_LetId",
                        column: x => x.LetId,
                        principalTable: "Let",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaljiLeta_Osoblje_OsobljeId",
                        column: x => x.OsobljeId,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StanicaLinija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinijaId = table.Column<int>(nullable: false),
                    StanicaPolazisteId = table.Column<int>(nullable: false),
                    StanicaOdredisteId = table.Column<int>(nullable: false),
                    PolazakVrijeme = table.Column<DateTime>(nullable: false),
                    DolazakVrijeme = table.Column<DateTime>(nullable: false),
                    Cijena = table.Column<double>(nullable: false)
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
                        name: "FK_StanicaLinija_Stanica_StanicaOdredisteId",
                        column: x => x.StanicaOdredisteId,
                        principalTable: "Stanica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StanicaLinija_Stanica_StanicaPolazisteId",
                        column: x => x.StanicaPolazisteId,
                        principalTable: "Stanica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AutobusnaKarta",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    StanicaLinijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutobusnaKarta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutobusnaKarta_StanicaLinija_StanicaLinijaId",
                        column: x => x.StanicaLinijaId,
                        principalTable: "StanicaLinija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aerodrom_GradId",
                table: "Aerodrom",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AutobusnaKarta_StanicaLinijaId",
                table: "AutobusnaKarta",
                column: "StanicaLinijaId");

            migrationBuilder.CreateIndex(
                name: "IX_AvioKarta_LetId",
                table: "AvioKarta",
                column: "LetId");

            migrationBuilder.CreateIndex(
                name: "IX_Avion_KompanijaId",
                table: "Avion",
                column: "KompanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_KompanijaId",
                table: "Bus",
                column: "KompanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_TipBusaId",
                table: "Bus",
                column: "TipBusaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiLeta_LetId",
                table: "DetaljiLeta",
                column: "LetId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiLeta_OsobljeId",
                table: "DetaljiLeta",
                column: "OsobljeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaId",
                table: "Grad",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Let_AerodromDoId",
                table: "Let",
                column: "AerodromDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Let_AerodromOdId",
                table: "Let",
                column: "AerodromOdId");

            migrationBuilder.CreateIndex(
                name: "IX_Let_AvionId",
                table: "Let",
                column: "AvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_BusId",
                table: "Linija",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_KondukterId",
                table: "Linija",
                column: "KondukterId");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_StanicaPocetnaId",
                table: "Linija",
                column: "StanicaPocetnaId");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_StanicaZadnjaId",
                table: "Linija",
                column: "StanicaZadnjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_Vozac1Id",
                table: "Linija",
                column: "Vozac1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Osoblje_SpolId",
                table: "Osoblje",
                column: "SpolId");

            migrationBuilder.CreateIndex(
                name: "IX_Osoblje_TipOsobljaId",
                table: "Osoblje",
                column: "TipOsobljaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stanica_GradId",
                table: "Stanica",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_StanicaLinija_LinijaId",
                table: "StanicaLinija",
                column: "LinijaId");

            migrationBuilder.CreateIndex(
                name: "IX_StanicaLinija_StanicaOdredisteId",
                table: "StanicaLinija",
                column: "StanicaOdredisteId");

            migrationBuilder.CreateIndex(
                name: "IX_StanicaLinija_StanicaPolazisteId",
                table: "StanicaLinija",
                column: "StanicaPolazisteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AutobusnaKarta");

            migrationBuilder.DropTable(
                name: "AvioKarta");

            migrationBuilder.DropTable(
                name: "DetaljiLeta");

            migrationBuilder.DropTable(
                name: "KlasaAvioKarte");

            migrationBuilder.DropTable(
                name: "TipKarte");

            migrationBuilder.DropTable(
                name: "VrstaKarte");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StanicaLinija");

            migrationBuilder.DropTable(
                name: "Let");

            migrationBuilder.DropTable(
                name: "Linija");

            migrationBuilder.DropTable(
                name: "Aerodrom");

            migrationBuilder.DropTable(
                name: "Avion");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "Osoblje");

            migrationBuilder.DropTable(
                name: "Stanica");

            migrationBuilder.DropTable(
                name: "Kompanija");

            migrationBuilder.DropTable(
                name: "TipBusa");

            migrationBuilder.DropTable(
                name: "Spol");

            migrationBuilder.DropTable(
                name: "TipOsoblja");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
