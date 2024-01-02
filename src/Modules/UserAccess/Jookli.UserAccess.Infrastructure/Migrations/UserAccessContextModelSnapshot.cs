﻿// <auto-generated />
using System;
using Jookli.UserAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jookli.UserAccess.Infrastructure.Migrations
{
    [DbContext(typeof(UserAccessContext))]
    partial class UserAccessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jookli.BuildingBlocks.Application.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccuredOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccess_OutboxMessages", (string)null);
                });

            modelBuilder.Entity("Jookli.BuildingBlocks.Infrastructure.Inbox.InboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccuredOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("UserAccess_InboxMessage", (string)null);
                });

            modelBuilder.Entity("Jookli.BuildingBlocks.Infrastructure.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EnqueueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccess_InternalCommands", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Address.AddressEntity", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAccess_Address", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Emails.AnonymousEmailEntity", b =>
                {
                    b.Property<Guid>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactEmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailId");

                    b.HasIndex("EmailId");

                    b.ToTable("UserAccess_AnonymousEmail", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Emails.EmailEntity", b =>
                {
                    b.Property<Guid>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmailId");

                    b.HasIndex("EmailId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccess_Email", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Location.LocationEntity", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("time");

                    b.Property<bool>("IsAllowed")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAccess_Location", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Location.LocationServicesEntity", b =>
                {
                    b.Property<Guid>("LocationServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccess_LocationServices", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.LoginAttempts.LoginAttemptEntity", b =>
                {
                    b.Property<Guid>("LoginAttemptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BadAuthorizationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SuccessfullAuthorizationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginAttemptId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccess_LoginAttempts", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Token.TokenEntity", b =>
                {
                    b.Property<Guid>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("Metadata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TokenId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccess_Tokens", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.User.UserEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AccountBlockedSince")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AccountBlockedUntil")
                        .HasColumnType("datetime2");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfLastActivity")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfLastActivityUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccountBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Premium")
                        .HasColumnType("bit");

                    b.Property<bool>("PushNotifications")
                        .HasColumnType("bit");

                    b.Property<int>("RegistrationSource")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccess_User", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.UserDetails.UserDetailsEntity", b =>
                {
                    b.Property<Guid>("UserDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AreaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaseInfoCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BaseInfoGender")
                        .HasColumnType("int");

                    b.Property<string>("CurrentRelationShip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interesets")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Legacy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfResidence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliticalViews")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserDetailsId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAccess_UserDetails", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.UsersDevice.UsersDeviceEntity", b =>
                {
                    b.Property<Guid>("UsersDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OsVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UsersDeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccess_UsersDevice", (string)null);
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Address.AddressEntity", b =>
                {
                    b.HasOne("Jookli.UserAccess.Domain.Entities.User.UserEntity", "User")
                        .WithOne("Address")
                        .HasForeignKey("Jookli.UserAccess.Domain.Entities.Address.AddressEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Emails.EmailEntity", b =>
                {
                    b.HasOne("Jookli.UserAccess.Domain.Entities.User.UserEntity", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Location.LocationEntity", b =>
                {
                    b.HasOne("Jookli.UserAccess.Domain.Entities.User.UserEntity", "User")
                        .WithOne("Location")
                        .HasForeignKey("Jookli.UserAccess.Domain.Entities.Location.LocationEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Location.LocationServicesEntity", b =>
                {
                    b.HasOne("Jookli.UserAccess.Domain.Entities.Location.LocationEntity", "Location")
                        .WithMany("Services")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.LoginAttempts.LoginAttemptEntity", b =>
                {
                    b.HasOne("Jookli.UserAccess.Domain.Entities.User.UserEntity", "User")
                        .WithMany("LoginAttempts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Token.TokenEntity", b =>
                {
                    b.HasOne("Jookli.UserAccess.Domain.Entities.User.UserEntity", "User")
                        .WithMany("Token")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.UserDetails.UserDetailsEntity", b =>
                {
                    b.HasOne("Jookli.UserAccess.Domain.Entities.User.UserEntity", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("Jookli.UserAccess.Domain.Entities.UserDetails.UserDetailsEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.UsersDevice.UsersDeviceEntity", b =>
                {
                    b.HasOne("Jookli.UserAccess.Domain.Entities.User.UserEntity", "User")
                        .WithMany("UsersDevice")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.Location.LocationEntity", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Jookli.UserAccess.Domain.Entities.User.UserEntity", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("LoginAttempts");

                    b.Navigation("Reports");

                    b.Navigation("Token");

                    b.Navigation("UserDetails")
                        .IsRequired();

                    b.Navigation("UsersDevice");
                });
#pragma warning restore 612, 618
        }
    }
}
