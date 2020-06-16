using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrentWiels.Migrations
{
    public partial class facturen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Werken_Facturen_FactuurId",
                table: "Werken");

            migrationBuilder.DropIndex(
                name: "IX_Werken_FactuurId",
                table: "Werken");

            migrationBuilder.DropColumn(
                name: "FactuurId",
                table: "Werken");

            migrationBuilder.DropColumn(
                name: "BetaaldOp",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "Btw",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "IsBetaald",
                table: "Facturen");

            migrationBuilder.AddColumn<int>(
                name: "ExtraWerklijnId",
                table: "Facturen",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDownloaded",
                table: "Facturen",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OfferteId",
                table: "Facturen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_ExtraWerklijnId",
                table: "Facturen",
                column: "ExtraWerklijnId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_OfferteId",
                table: "Facturen",
                column: "OfferteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_Werken_ExtraWerklijnId",
                table: "Facturen",
                column: "ExtraWerklijnId",
                principalTable: "Werken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_Offertes_OfferteId",
                table: "Facturen",
                column: "OfferteId",
                principalTable: "Offertes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_Werken_ExtraWerklijnId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_Offertes_OfferteId",
                table: "Facturen");

            migrationBuilder.DropIndex(
                name: "IX_Facturen_ExtraWerklijnId",
                table: "Facturen");

            migrationBuilder.DropIndex(
                name: "IX_Facturen_OfferteId",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "ExtraWerklijnId",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "IsDownloaded",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "OfferteId",
                table: "Facturen");

            migrationBuilder.AddColumn<int>(
                name: "FactuurId",
                table: "Werken",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BetaaldOp",
                table: "Facturen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Btw",
                table: "Facturen",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBetaald",
                table: "Facturen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Werken_FactuurId",
                table: "Werken",
                column: "FactuurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Werken_Facturen_FactuurId",
                table: "Werken",
                column: "FactuurId",
                principalTable: "Facturen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
