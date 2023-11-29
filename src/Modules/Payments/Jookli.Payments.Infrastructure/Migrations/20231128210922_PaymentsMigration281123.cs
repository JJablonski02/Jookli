using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Payments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaymentsMigration281123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Payments_User");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payments_User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Payments_Card",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payments_User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments_Card");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Payments_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
