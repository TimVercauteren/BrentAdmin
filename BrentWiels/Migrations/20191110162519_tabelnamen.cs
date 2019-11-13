using Microsoft.EntityFrameworkCore.Migrations;

namespace BrentWiels.Migrations
{
    public partial class tabelnamen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Klanten_KlantId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Klanten_Adres_AdresId",
                table: "Klanten");

            migrationBuilder.DropForeignKey(
                name: "FK_Klanten_ContactInformatie_ContactId",
                table: "Klanten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInformatie",
                table: "ContactInformatie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adres",
                table: "Adres");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documenten");

            migrationBuilder.RenameTable(
                name: "ContactInformatie",
                newName: "ContactInfos");

            migrationBuilder.RenameTable(
                name: "Adres",
                newName: "Adressen");

            migrationBuilder.RenameIndex(
                name: "IX_Document_KlantId",
                table: "Documenten",
                newName: "IX_Documenten_KlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documenten",
                table: "Documenten",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adressen",
                table: "Adressen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documenten_Klanten_KlantId",
                table: "Documenten",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Klanten_Adressen_AdresId",
                table: "Klanten",
                column: "AdresId",
                principalTable: "Adressen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Klanten_ContactInfos_ContactId",
                table: "Klanten",
                column: "ContactId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documenten_Klanten_KlantId",
                table: "Documenten");

            migrationBuilder.DropForeignKey(
                name: "FK_Klanten_Adressen_AdresId",
                table: "Klanten");

            migrationBuilder.DropForeignKey(
                name: "FK_Klanten_ContactInfos_ContactId",
                table: "Klanten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documenten",
                table: "Documenten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adressen",
                table: "Adressen");

            migrationBuilder.RenameTable(
                name: "Documenten",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "ContactInfos",
                newName: "ContactInformatie");

            migrationBuilder.RenameTable(
                name: "Adressen",
                newName: "Adres");

            migrationBuilder.RenameIndex(
                name: "IX_Documenten_KlantId",
                table: "Document",
                newName: "IX_Document_KlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInformatie",
                table: "ContactInformatie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adres",
                table: "Adres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Klanten_KlantId",
                table: "Document",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Klanten_Adres_AdresId",
                table: "Klanten",
                column: "AdresId",
                principalTable: "Adres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Klanten_ContactInformatie_ContactId",
                table: "Klanten",
                column: "ContactId",
                principalTable: "ContactInformatie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
