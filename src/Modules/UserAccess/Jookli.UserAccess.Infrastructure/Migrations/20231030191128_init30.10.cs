using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init3010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                schema: "user",
                newName: "OutboxMessages",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "InternalCommands",
                newName: "InternalCommands",
                newSchema: "user");

            migrationBuilder.CreateTable(
                name: "InboxMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxMessage", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxMessage");

            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                schema: "users",
                newName: "OutboxMessages",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "InternalCommands",
                schema: "user",
                newName: "InternalCommands");
        }
    }
}
