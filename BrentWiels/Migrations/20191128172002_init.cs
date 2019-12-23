using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrentWiels.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    StraatNaam = table.Column<string>(nullable: true),
                    HuisNummer = table.Column<string>(nullable: true),
                    BusNummer = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacten",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    Email = table.Column<string>(nullable: true),
                    TelefoonNummer = table.Column<string>(nullable: true),
                    BtwNummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Omschrijvingen",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    Omschrijving = table.Column<string>(nullable: true),
                    IsFavoriet = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Omschrijvingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    AdresId = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klanten_Adressen_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adressen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Klanten_Contacten_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturen",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    FileName = table.Column<string>(nullable: true),
                    KlantId = table.Column<int>(nullable: true),
                    Btw = table.Column<decimal>(),
                    FactuurNummer = table.Column<string>(nullable: true),
                    IsBetaald = table.Column<bool>(),
                    BetaaldOp = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturen_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offertes",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    OfferteNummer = table.Column<string>(nullable: true),
                    VervalDatum = table.Column<DateTime>(),
                    VersieNummer = table.Column<int>(),
                    FileName = table.Column<string>(nullable: true),
                    KlantId = table.Column<int>(nullable: true),
                    Btw = table.Column<decimal>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offertes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offertes_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Werken",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    OmschrijvingId = table.Column<int>(nullable: true),
                    NettoPrijs = table.Column<decimal>(),
                    PercentageWinst = table.Column<decimal>(),
                    FactuurId = table.Column<int>(nullable: true),
                    OfferteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Werken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Werken_Facturen_FactuurId",
                        column: x => x.FactuurId,
                        principalTable: "Facturen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Werken_Offertes_OfferteId",
                        column: x => x.OfferteId,
                        principalTable: "Offertes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Werken_Omschrijvingen_OmschrijvingId",
                        column: x => x.OmschrijvingId,
                        principalTable: "Omschrijvingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_KlantId",
                table: "Facturen",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_AdresId",
                table: "Klanten",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_ContactId",
                table: "Klanten",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Offertes_KlantId",
                table: "Offertes",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Werken_FactuurId",
                table: "Werken",
                column: "FactuurId");

            migrationBuilder.CreateIndex(
                name: "IX_Werken_OfferteId",
                table: "Werken",
                column: "OfferteId");

            migrationBuilder.CreateIndex(
                name: "IX_Werken_OmschrijvingId",
                table: "Werken",
                column: "OmschrijvingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Werken");

            migrationBuilder.DropTable(
                name: "Facturen");

            migrationBuilder.DropTable(
                name: "Offertes");

            migrationBuilder.DropTable(
                name: "Omschrijvingen");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "Contacten");
        }
    }
}
