using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageEntity_User_UserEntityUserID",
                table: "MessageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_VoiceMessageEntity_User_UserEntityUserID",
                table: "VoiceMessageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutboxMessages",
                schema: "users",
                table: "OutboxMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalCommands",
                schema: "user",
                table: "InternalCommands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboxMessage",
                table: "InboxMessage");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UserAccess_User");

            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                schema: "users",
                newName: "UserAccess_OutboxMessages");

            migrationBuilder.RenameTable(
                name: "InternalCommands",
                schema: "user",
                newName: "UserAccess_InternalCommands");

            migrationBuilder.RenameTable(
                name: "InboxMessage",
                newName: "UserAccess_InboxMessage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccess_User",
                table: "UserAccess_User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccess_OutboxMessages",
                table: "UserAccess_OutboxMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccess_InternalCommands",
                table: "UserAccess_InternalCommands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccess_InboxMessage",
                table: "UserAccess_InboxMessage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_User_UserID",
                table: "UserAccess_User",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_InboxMessage_Id",
                table: "UserAccess_InboxMessage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageEntity_UserAccess_User_UserEntityUserID",
                table: "MessageEntity",
                column: "UserEntityUserID",
                principalTable: "UserAccess_User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_VoiceMessageEntity_UserAccess_User_UserEntityUserID",
                table: "VoiceMessageEntity",
                column: "UserEntityUserID",
                principalTable: "UserAccess_User",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageEntity_UserAccess_User_UserEntityUserID",
                table: "MessageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_VoiceMessageEntity_UserAccess_User_UserEntityUserID",
                table: "VoiceMessageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccess_User",
                table: "UserAccess_User");

            migrationBuilder.DropIndex(
                name: "IX_UserAccess_User_UserID",
                table: "UserAccess_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccess_OutboxMessages",
                table: "UserAccess_OutboxMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccess_InternalCommands",
                table: "UserAccess_InternalCommands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccess_InboxMessage",
                table: "UserAccess_InboxMessage");

            migrationBuilder.DropIndex(
                name: "IX_UserAccess_InboxMessage_Id",
                table: "UserAccess_InboxMessage");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.RenameTable(
                name: "UserAccess_User",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserAccess_OutboxMessages",
                newName: "OutboxMessages",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "UserAccess_InternalCommands",
                newName: "InternalCommands",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "UserAccess_InboxMessage",
                newName: "InboxMessage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutboxMessages",
                schema: "users",
                table: "OutboxMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalCommands",
                schema: "user",
                table: "InternalCommands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboxMessage",
                table: "InboxMessage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageEntity_User_UserEntityUserID",
                table: "MessageEntity",
                column: "UserEntityUserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_VoiceMessageEntity_User_UserEntityUserID",
                table: "VoiceMessageEntity",
                column: "UserEntityUserID",
                principalTable: "User",
                principalColumn: "UserID");
        }
    }
}
