using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Games.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfilesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfileEntityProfileId",
                table: "Games_Game",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games_Profile",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Game_ProfileEntityProfileId",
                table: "Games_Game",
                column: "ProfileEntityProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Game_Games_Profile_ProfileEntityProfileId",
                table: "Games_Game",
                column: "ProfileEntityProfileId",
                principalTable: "Games_Profile",
                principalColumn: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Game_Games_Profile_ProfileEntityProfileId",
                table: "Games_Game");

            migrationBuilder.DropTable(
                name: "Games_Profile");

            migrationBuilder.DropIndex(
                name: "IX_Games_Game_ProfileEntityProfileId",
                table: "Games_Game");

            migrationBuilder.DropColumn(
                name: "ProfileEntityProfileId",
                table: "Games_Game");
        }
    }
}
