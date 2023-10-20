using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoiceMessage");

            migrationBuilder.CreateTable(
                name: "InternalCommands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
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
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoiceMessageEntity",
                columns: table => new
                {
                    VoiceMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoiceMessageDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoiceMessageLength = table.Column<int>(type: "int", nullable: false),
                    UserEntityUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceMessageEntity", x => x.VoiceMessageId);
                    table.ForeignKey(
                        name: "FK_VoiceMessageEntity_User_UserEntityUserID",
                        column: x => x.UserEntityUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoiceMessageEntity_UserEntityUserID",
                table: "VoiceMessageEntity",
                column: "UserEntityUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalCommands");

            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "VoiceMessageEntity");

            migrationBuilder.CreateTable(
                name: "VoiceMessage",
                columns: table => new
                {
                    VoiceMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEntityUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoiceMessageDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoiceMessageLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceMessage", x => x.VoiceMessageId);
                    table.ForeignKey(
                        name: "FK_VoiceMessage_User_UserEntityUserID",
                        column: x => x.UserEntityUserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoiceMessage_UserEntityUserID",
                table: "VoiceMessage",
                column: "UserEntityUserID");
        }
    }
}
