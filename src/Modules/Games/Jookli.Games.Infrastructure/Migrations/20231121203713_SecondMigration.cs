using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Games.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OutboxMessagesGlobal",
                table: "OutboxMessagesGlobal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalCommands",
                table: "InternalCommands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboxMessage",
                table: "InboxMessage");

            migrationBuilder.RenameTable(
                name: "OutboxMessagesGlobal",
                newName: "Games_OutboxMessages");

            migrationBuilder.RenameTable(
                name: "InternalCommands",
                newName: "Games_InternalCommands");

            migrationBuilder.RenameTable(
                name: "InboxMessage",
                newName: "Games_InboxMessage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games_OutboxMessages",
                table: "Games_OutboxMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games_InternalCommands",
                table: "Games_InternalCommands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games_InboxMessage",
                table: "Games_InboxMessage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_InboxMessage_Id",
                table: "Games_InboxMessage",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games_OutboxMessages",
                table: "Games_OutboxMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games_InternalCommands",
                table: "Games_InternalCommands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games_InboxMessage",
                table: "Games_InboxMessage");

            migrationBuilder.DropIndex(
                name: "IX_Games_InboxMessage_Id",
                table: "Games_InboxMessage");

            migrationBuilder.RenameTable(
                name: "Games_OutboxMessages",
                newName: "OutboxMessagesGlobal");

            migrationBuilder.RenameTable(
                name: "Games_InternalCommands",
                newName: "InternalCommands");

            migrationBuilder.RenameTable(
                name: "Games_InboxMessage",
                newName: "InboxMessage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutboxMessagesGlobal",
                table: "OutboxMessagesGlobal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalCommands",
                table: "InternalCommands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboxMessage",
                table: "InboxMessage",
                column: "Id");
        }
    }
}
