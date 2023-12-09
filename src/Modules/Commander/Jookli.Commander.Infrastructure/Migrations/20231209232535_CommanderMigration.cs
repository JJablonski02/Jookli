using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jookli.Commander.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CommanderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commander_EmailAccount",
                columns: table => new
                {
                    EmailAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pop3Server = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pop3Port = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pop3Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pop3Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpServer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpPort = table.Column<int>(type: "int", nullable: true),
                    SmtpLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImapServer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImapPort = table.Column<int>(type: "int", nullable: true),
                    ImapLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImapPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commander_EmailAccount", x => x.EmailAccountId);
                });

            migrationBuilder.CreateTable(
                name: "Commander_InboxMessage",
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
                    table.PrimaryKey("PK_Commander_InboxMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commander_InternalCommands",
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
                    table.PrimaryKey("PK_Commander_InternalCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commander_OutboxMessages",
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
                    table.PrimaryKey("PK_Commander_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commander_User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commander_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Commander_Email",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recipement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commander_Email", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Commander_Email_Commander_EmailAccount_EmailAccountId",
                        column: x => x.EmailAccountId,
                        principalTable: "Commander_EmailAccount",
                        principalColumn: "EmailAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commander_EmailTemplate",
                columns: table => new
                {
                    EmailTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    EmailTemplate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commander_EmailTemplate", x => x.EmailTemplateId);
                    table.ForeignKey(
                        name: "FK_Commander_EmailTemplate_Commander_EmailAccount_EmailAccountId",
                        column: x => x.EmailAccountId,
                        principalTable: "Commander_EmailAccount",
                        principalColumn: "EmailAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commander_EmailAttached",
                columns: table => new
                {
                    EmailAttachedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commander_EmailAttached", x => x.EmailAttachedId);
                    table.ForeignKey(
                        name: "FK_Commander_EmailAttached_Commander_Email_EmailAttachedId",
                        column: x => x.EmailAttachedId,
                        principalTable: "Commander_Email",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commander_EmailTemplateAttached",
                columns: table => new
                {
                    EmailTemplateAttachedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commander_EmailTemplateAttached", x => x.EmailTemplateAttachedId);
                    table.ForeignKey(
                        name: "FK_Commander_EmailTemplateAttached_Commander_EmailTemplate_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "Commander_EmailTemplate",
                        principalColumn: "EmailTemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Commander_EmailAccount",
                columns: new[] { "EmailAccountId", "EmailAddress", "ImapLogin", "ImapPassword", "ImapPort", "ImapServer", "Name", "Pop3Login", "Pop3Password", "Pop3Port", "Pop3Server", "SmtpLogin", "SmtpPassword", "SmtpPort", "SmtpServer" },
                values: new object[] { new Guid("428ba167-51c8-422b-9248-0fa681e744a4"), null, null, null, null, null, "Support", null, null, null, null, "support@joyprofits.com", "", 0, "" });

            migrationBuilder.InsertData(
                table: "Commander_EmailTemplate",
                columns: new[] { "EmailTemplateId", "Active", "Content", "EmailAccountId", "EmailName", "EmailTemplate", "SenderName", "Subject" },
                values: new object[,]
                {
                    { new Guid("284d5a55-9e72-4bb8-9810-40f22d46daae"), true, "", new Guid("428ba167-51c8-422b-9248-0fa681e744a4"), "Resetowanie hasła - JoyProfits.com", 1, "JoyProfits - Earn with us", "Resetowanie hasła JoyProfits.com" },
                    { new Guid("8075ef16-0179-4bab-b1b0-0d616316af8b"), true, "", new Guid("428ba167-51c8-422b-9248-0fa681e744a4"), "Aktywacja konta - JoyProfits.com", 0, "JoyProfits - Earn with us", "Rejestracja konta JoyProfits.com" },
                    { new Guid("bb4271c5-5b8b-4c22-84ac-214cdef19231"), true, "", new Guid("428ba167-51c8-422b-9248-0fa681e744a4"), "Potwierdzenie otrzymania wiadomości - JoyProfits.com", 5, "JoyProfits - Earn with us", "Dziękujemy za kontakt z JoyProfits.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commander_Email_EmailAccountId",
                table: "Commander_Email",
                column: "EmailAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_Email_EmailId",
                table: "Commander_Email",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_EmailAccount_EmailAccountId",
                table: "Commander_EmailAccount",
                column: "EmailAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_EmailAttached_EmailAttachedId",
                table: "Commander_EmailAttached",
                column: "EmailAttachedId");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_EmailTemplate_EmailAccountId",
                table: "Commander_EmailTemplate",
                column: "EmailAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_EmailTemplate_EmailTemplateId",
                table: "Commander_EmailTemplate",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_EmailTemplateAttached_EmailTemplateAttachedId",
                table: "Commander_EmailTemplateAttached",
                column: "EmailTemplateAttachedId");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_EmailTemplateAttached_EmailTemplateId",
                table: "Commander_EmailTemplateAttached",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_InboxMessage_Id",
                table: "Commander_InboxMessage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_User_UserId",
                table: "Commander_User",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commander_EmailAttached");

            migrationBuilder.DropTable(
                name: "Commander_EmailTemplateAttached");

            migrationBuilder.DropTable(
                name: "Commander_InboxMessage");

            migrationBuilder.DropTable(
                name: "Commander_InternalCommands");

            migrationBuilder.DropTable(
                name: "Commander_OutboxMessages");

            migrationBuilder.DropTable(
                name: "Commander_User");

            migrationBuilder.DropTable(
                name: "Commander_Email");

            migrationBuilder.DropTable(
                name: "Commander_EmailTemplate");

            migrationBuilder.DropTable(
                name: "Commander_EmailAccount");
        }
    }
}
