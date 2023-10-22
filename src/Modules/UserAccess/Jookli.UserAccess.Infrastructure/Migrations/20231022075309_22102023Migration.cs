using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _22102023Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "User");
        }
    }
}
