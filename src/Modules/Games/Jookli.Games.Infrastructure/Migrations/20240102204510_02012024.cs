using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Games.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _02012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGamesId",
                table: "Games_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGamesId",
                table: "Games_User");
        }
    }
}
