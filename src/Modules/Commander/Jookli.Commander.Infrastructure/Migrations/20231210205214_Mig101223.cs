using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Commander.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig101223 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailEntityId",
                table: "Commander_EmailAttached",
                newName: "EmailId");

            migrationBuilder.RenameColumn(
                name: "Recipement",
                table: "Commander_Email",
                newName: "Receiver");

            migrationBuilder.UpdateData(
                table: "Commander_EmailAccount",
                keyColumn: "EmailAccountId",
                keyValue: new Guid("428ba167-51c8-422b-9248-0fa681e744a4"),
                columns: new[] { "SmtpPassword", "SmtpPort", "SmtpServer" },
                values: new object[] { "b_DPKkOK", 587, "serwer2377612.home.pl " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "Commander_EmailAttached",
                newName: "EmailEntityId");

            migrationBuilder.RenameColumn(
                name: "Receiver",
                table: "Commander_Email",
                newName: "Recipement");

            migrationBuilder.UpdateData(
                table: "Commander_EmailAccount",
                keyColumn: "EmailAccountId",
                keyValue: new Guid("428ba167-51c8-422b-9248-0fa681e744a4"),
                columns: new[] { "SmtpPassword", "SmtpPort", "SmtpServer" },
                values: new object[] { "", 0, "" });
        }
    }
}
