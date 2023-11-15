using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.Payments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaymentsFixedBugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OccurredOn",
                table: "Payments_InboxMessage",
                newName: "OccuredOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OccuredOn",
                table: "Payments_InboxMessage",
                newName: "OccurredOn");
        }
    }
}
