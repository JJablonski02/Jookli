using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Games.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GamesMigration101223 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games_AyetUsers",
                columns: table => new
                {
                    AyetUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payout = table.Column<float>(type: "real", nullable: false),
                    CurrencyAmount = table.Column<float>(type: "real", nullable: false),
                    externalIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIntId = table.Column<int>(type: "int", nullable: false),
                    PlacementIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdslotId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_AyetUsers", x => x.AyetUserId);
                    table.ForeignKey(
                        name: "FK_Games_AyetUsers_Games_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Games_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games_TapJoyUsers",
                columns: table => new
                {
                    TapJoyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_TapJoyUsers", x => x.TapJoyUserId);
                    table.ForeignKey(
                        name: "FK_Games_TapJoyUsers_Games_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Games_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_AyetUsers_AyetUserId",
                table: "Games_AyetUsers",
                column: "AyetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AyetUsers_UserId",
                table: "Games_AyetUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TapJoyUsers_TapJoyUserId",
                table: "Games_TapJoyUsers",
                column: "TapJoyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TapJoyUsers_UserId",
                table: "Games_TapJoyUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games_AyetUsers");

            migrationBuilder.DropTable(
                name: "Games_TapJoyUsers");
        }
    }
}
