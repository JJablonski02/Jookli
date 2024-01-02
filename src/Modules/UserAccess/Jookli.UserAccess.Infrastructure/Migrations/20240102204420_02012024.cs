using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _02012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccess_AnonymousEmail",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess_AnonymousEmail", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_Email",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess_Email", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_UserAccess_Email_UserAccess_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccess_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_AnonymousEmail_EmailId",
                table: "UserAccess_AnonymousEmail",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_Email_EmailId",
                table: "UserAccess_Email",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_Email_UserId",
                table: "UserAccess_Email",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccess_AnonymousEmail");

            migrationBuilder.DropTable(
                name: "UserAccess_Email");
        }
    }
}
