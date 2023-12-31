﻿// <auto-generated />
using System;
using Jookli.Games.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jookli.Games.Infrastructure.Migrations
{
    [DbContext(typeof(GamesContext))]
    [Migration("20240102204510_02012024")]
    partial class _02012024
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Games_OutboxMessages", (string)null);
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

                    b.ToTable("Games_InboxMessage", (string)null);
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

                    b.ToTable("Games_InternalCommands", (string)null);
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.AyeTStudios.AyetUserEntity", b =>
                {
                    b.Property<Guid>("AyetUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdslotId")
                        .HasColumnType("int");

                    b.Property<float>("CurrencyAmount")
                        .HasColumnType("real");

                    b.Property<float>("Payout")
                        .HasColumnType("real");

                    b.Property<string>("PlacementIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserIntId")
                        .HasColumnType("int");

                    b.Property<string>("externalIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AyetUserId");

                    b.HasIndex("AyetUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Games_AyetUsers", (string)null);
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.Game.GameEntity", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProfileEntityProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GameId");

                    b.HasIndex("ProfileEntityProfileId");

                    b.ToTable("Games_Game", (string)null);
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.Profile.ProfileEntity", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProfileId");

                    b.ToTable("Games_Profile", (string)null);
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.TapJoy.TapJoyUserEntity", b =>
                {
                    b.Property<Guid>("TapJoyUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TapJoyUserId");

                    b.HasIndex("TapJoyUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Games_TapJoyUsers", (string)null);
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.User.UserEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserGamesId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Games_User", (string)null);
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.AyeTStudios.AyetUserEntity", b =>
                {
                    b.HasOne("Jookli.Games.Domain.Entities.User.UserEntity", "User")
                        .WithMany("AyetUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.Game.GameEntity", b =>
                {
                    b.HasOne("Jookli.Games.Domain.Entities.Profile.ProfileEntity", null)
                        .WithMany("Games")
                        .HasForeignKey("ProfileEntityProfileId");
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.TapJoy.TapJoyUserEntity", b =>
                {
                    b.HasOne("Jookli.Games.Domain.Entities.User.UserEntity", "User")
                        .WithMany("TapJoyUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.Profile.ProfileEntity", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Jookli.Games.Domain.Entities.User.UserEntity", b =>
                {
                    b.Navigation("AyetUsers");

                    b.Navigation("TapJoyUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
