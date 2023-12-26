using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jookli.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAccessMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW UserAccess_AuthV
                                   AS 
                                   SELECT 
                                    User.UserId, 
                                    User.Email, 
                                    User.Password, 
                                    User.IsDeleted,
                                    User.IsAccountBlocked
                                    User.AccountBlockedSince
                                    User.AccountBlockedUntil
                                   FROM UserAccess_User AS User");
            

        migrationBuilder.CreateTable(
                name: "UserAccess_InboxMessage",
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
                    table.PrimaryKey("PK_UserAccess_InboxMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_InternalCommands",
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
                    table.PrimaryKey("PK_UserAccess_InternalCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_OutboxMessages",
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
                    table.PrimaryKey("PK_UserAccess_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    RegistrationSource = table.Column<int>(type: "int", nullable: false),
                    DateOfLastActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastActivityUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Premium = table.Column<bool>(type: "bit", nullable: false),
                    PushNotifications = table.Column<bool>(type: "bit", nullable: false),
                    IsAccountBlocked = table.Column<bool>(type: "bit", nullable: false),
                    AccountBlockedSince = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountBlockedUntil = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_UserAccess_Address_UserAccess_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccess_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_Location",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    Interval = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_UserAccess_Location_UserAccess_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccess_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_LoginAttempts",
                columns: table => new
                {
                    LoginAttemptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuccessfullAuthorizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BadAuthorizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess_LoginAttempts", x => x.LoginAttemptId);
                    table.ForeignKey(
                        name: "FK_UserAccess_LoginAttempts_UserAccess_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccess_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_UserDetails",
                columns: table => new
                {
                    UserDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BaseInfoGender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseInfoCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfResidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Legacy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliticalViews = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentRelationShip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interesets = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess_UserDetails", x => x.UserDetailsId);
                    table.ForeignKey(
                        name: "FK_UserAccess_UserDetails_UserAccess_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccess_User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess_LocationServices",
                columns: table => new
                {
                    LocationServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess_LocationServices", x => x.LocationServiceId);
                    table.ForeignKey(
                        name: "FK_UserAccess_LocationServices_UserAccess_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "UserAccess_Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_Address_UserId",
                table: "UserAccess_Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_InboxMessage_Id",
                table: "UserAccess_InboxMessage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_Location_UserId",
                table: "UserAccess_Location",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_LocationServices_LocationId",
                table: "UserAccess_LocationServices",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_LoginAttempts_UserId",
                table: "UserAccess_LoginAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_User_UserId",
                table: "UserAccess_User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_UserDetails_UserId",
                table: "UserAccess_UserDetails",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS dbo.UserAccess_AuthV;");

            migrationBuilder.DropTable(
                name: "UserAccess_Address");

            migrationBuilder.DropTable(
                name: "UserAccess_InboxMessage");

            migrationBuilder.DropTable(
                name: "UserAccess_InternalCommands");

            migrationBuilder.DropTable(
                name: "UserAccess_LocationServices");

            migrationBuilder.DropTable(
                name: "UserAccess_LoginAttempts");

            migrationBuilder.DropTable(
                name: "UserAccess_OutboxMessages");

            migrationBuilder.DropTable(
                name: "UserAccess_UserDetails");

            migrationBuilder.DropTable(
                name: "UserAccess_Location");

            migrationBuilder.DropTable(
                name: "UserAccess_User");
        }
    }
}
