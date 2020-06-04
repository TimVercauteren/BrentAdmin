using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrentWiels.Migrations
{
    public partial class datum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_Klanten_KlantId",
                table: "Offertes");

            migrationBuilder.AlterColumn<int>(
                name: "KlantId",
                table: "Offertes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Offertes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Klanten",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Offertes_Klanten_KlantId",
                table: "Offertes",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_Klanten_KlantId",
                table: "Offertes");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Offertes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Klanten");

            migrationBuilder.AlterColumn<int>(
                name: "KlantId",
                table: "Offertes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Offertes_Klanten_KlantId",
                table: "Offertes",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
