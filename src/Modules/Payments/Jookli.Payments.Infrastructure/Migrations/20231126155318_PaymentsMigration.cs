using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Payments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaymentsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments_Card",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1Check = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2Check = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressZipCheck = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvcCheck = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultForCurrency = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DynamicLast4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fingerprint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpYear = table.Column<long>(type: "bigint", nullable: false),
                    Iin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenizationMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments_Card", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Payments_InboxMessage",
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
                    table.PrimaryKey("PK_Payments_InboxMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments_InternalCommands",
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
                    table.PrimaryKey("PK_Payments_InternalCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments_OutboxMessages",
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
                    table.PrimaryKey("PK_Payments_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments_User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardEntityCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Payments_User_Payments_Card_CardEntityCardId",
                        column: x => x.CardEntityCardId,
                        principalTable: "Payments_Card",
                        principalColumn: "CardId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_User_CardEntityCardId",
                table: "Payments_User",
                column: "CardEntityCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments_InboxMessage");

            migrationBuilder.DropTable(
                name: "Payments_InternalCommands");

            migrationBuilder.DropTable(
                name: "Payments_OutboxMessages");

            migrationBuilder.DropTable(
                name: "Payments_User");

            migrationBuilder.DropTable(
                name: "Payments_Card");
        }
    }
}
