using Microsoft.EntityFrameworkCore.Migrations;

namespace BrentWiels.Migrations
{
    public partial class offerteid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_Offertes_OfferteId",
                table: "Facturen");

            migrationBuilder.AlterColumn<int>(
                name: "OfferteId",
                table: "Facturen",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_Offertes_OfferteId",
                table: "Facturen",
                column: "OfferteId",
                principalTable: "Offertes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_Offertes_OfferteId",
                table: "Facturen");

            migrationBuilder.AlterColumn<int>(
                name: "OfferteId",
                table: "Facturen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_Offertes_OfferteId",
                table: "Facturen",
                column: "OfferteId",
                principalTable: "Offertes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
