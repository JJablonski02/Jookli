using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Games.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GamesMigration281123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Games_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Games_User");
        }
    }
}
