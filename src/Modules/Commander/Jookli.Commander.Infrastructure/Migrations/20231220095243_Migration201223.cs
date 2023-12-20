using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Commander.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration201223 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Commander_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Commander_EmailTemplate",
                keyColumn: "EmailTemplateId",
                keyValue: new Guid("284d5a55-9e72-4bb8-9810-40f22d46daae"),
                columns: new[] { "EmailName", "EmailTemplate", "Subject" },
                values: new object[] { "Resetowanie hasła - JoyProfits", 2, "Hasło zresetowane - JoyProfits" });

            migrationBuilder.UpdateData(
                table: "Commander_EmailTemplate",
                keyColumn: "EmailTemplateId",
                keyValue: new Guid("8075ef16-0179-4bab-b1b0-0d616316af8b"),
                column: "Subject",
                value: "Rejestracja konta - JoyProfits");

            migrationBuilder.UpdateData(
                table: "Commander_EmailTemplate",
                keyColumn: "EmailTemplateId",
                keyValue: new Guid("bb4271c5-5b8b-4c22-84ac-214cdef19231"),
                columns: new[] { "EmailName", "Subject" },
                values: new object[] { "Potwierdzenie wysłania wiadomości - JoyProfits", "Dziękujemy za kontakt z JoyProfits" });

            migrationBuilder.InsertData(
                table: "Commander_EmailTemplate",
                columns: new[] { "EmailTemplateId", "Active", "Content", "EmailAccountId", "EmailName", "EmailTemplate", "SenderName", "Subject" },
                values: new object[] { new Guid("aaefb675-15a3-4776-9ce9-0184ef577014"), true, "", new Guid("428ba167-51c8-422b-9248-0fa681e744a4"), "Próba odzyskania hasła - JoyProfits", 1, "JoyProfits - Earn with us", "Odzyskiwanie hasła - JoyProfits" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commander_EmailTemplate",
                keyColumn: "EmailTemplateId",
                keyValue: new Guid("aaefb675-15a3-4776-9ce9-0184ef577014"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Commander_User");

            migrationBuilder.UpdateData(
                table: "Commander_EmailTemplate",
                keyColumn: "EmailTemplateId",
                keyValue: new Guid("284d5a55-9e72-4bb8-9810-40f22d46daae"),
                columns: new[] { "EmailName", "EmailTemplate", "Subject" },
                values: new object[] { "Resetowanie hasła - JoyProfits.com", 1, "Resetowanie hasła JoyProfits.com" });

            migrationBuilder.UpdateData(
                table: "Commander_EmailTemplate",
                keyColumn: "EmailTemplateId",
                keyValue: new Guid("8075ef16-0179-4bab-b1b0-0d616316af8b"),
                column: "Subject",
                value: "Rejestracja konta JoyProfits.com");

            migrationBuilder.UpdateData(
                table: "Commander_EmailTemplate",
                keyColumn: "EmailTemplateId",
                keyValue: new Guid("bb4271c5-5b8b-4c22-84ac-214cdef19231"),
                columns: new[] { "EmailName", "Subject" },
                values: new object[] { "Potwierdzenie otrzymania wiadomości - JoyProfits.com", "Dziękujemy za kontakt z JoyProfits.com" });
        }
    }
}
