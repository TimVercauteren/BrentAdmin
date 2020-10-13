using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrentWiels.Migrations
{
    public partial class factuurdatum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FactuurDatum",
                table: "Facturen",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FactuurDatum",
                table: "Facturen");
        }
    }
}
