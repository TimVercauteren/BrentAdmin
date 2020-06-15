using Microsoft.EntityFrameworkCore.Migrations;

namespace BrentWiels.Migrations
{
    public partial class klantenref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlantenRef",
                table: "Klanten",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KlantenRef",
                table: "Klanten");
        }
    }
}
