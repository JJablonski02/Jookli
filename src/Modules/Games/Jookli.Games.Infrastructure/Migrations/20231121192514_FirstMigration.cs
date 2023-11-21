using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Games.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games_Game",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    GameOwner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Game", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "InboxMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalCommands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnqueueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessagesGlobal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessagesGlobal", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games_Game");

            migrationBuilder.DropTable(
                name: "InboxMessage");

            migrationBuilder.DropTable(
                name: "InternalCommands");

            migrationBuilder.DropTable(
                name: "OutboxMessagesGlobal");
        }
    }
}
