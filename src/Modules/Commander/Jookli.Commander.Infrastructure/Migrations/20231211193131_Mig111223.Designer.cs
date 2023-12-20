﻿// <auto-generated />
using System;
using Jookli.Commander.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jookli.Commander.Infrastructure.Migrations
{
    [DbContext(typeof(CommanderContext))]
    [Migration("20231211193131_Mig111223")]
    partial class Mig111223
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

                    b.ToTable("Commander_OutboxMessages", (string)null);
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

                    b.ToTable("Commander_InboxMessage", (string)null);
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

                    b.ToTable("Commander_InternalCommands", (string)null);
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.Email.EmailAttachedEntity", b =>
                {
                    b.Property<Guid>("EmailAttachedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailAttachedId");

                    b.HasIndex("EmailAttachedId");

                    b.ToTable("Commander_EmailAttached", (string)null);
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.Email.EmailEntity", b =>
                {
                    b.Property<Guid>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmailAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Receiver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailId");

                    b.HasIndex("EmailAccountId");

                    b.HasIndex("EmailId");

                    b.ToTable("Commander_Email", (string)null);
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.EmailAccount.EmailAccountEntity", b =>
                {
                    b.Property<Guid>("EmailAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImapLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImapPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImapPort")
                        .HasColumnType("int");

                    b.Property<string>("ImapServer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pop3Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pop3Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pop3Port")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pop3Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmtpLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmtpPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SmtpPort")
                        .HasColumnType("int");

                    b.Property<string>("SmtpServer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailAccountId");

                    b.HasIndex("EmailAccountId");

                    b.ToTable("Commander_EmailAccount", (string)null);

                    b.HasData(
                        new
                        {
                            EmailAccountId = new Guid("428ba167-51c8-422b-9248-0fa681e744a4"),
                            Name = "Support",
                            SmtpLogin = "support@joyprofits.com",
                            SmtpPassword = "b_DPKkOK",
                            SmtpPort = 587,
                            SmtpServer = "serwer2377612.home.pl "
                        });
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.EmailTemplate.EmailTemplateAttachedEntity", b =>
                {
                    b.Property<Guid>("EmailTemplateAttachedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmailTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailTemplateAttachedId");

                    b.HasIndex("EmailTemplateAttachedId");

                    b.HasIndex("EmailTemplateId");

                    b.ToTable("Commander_EmailTemplateAttached", (string)null);
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.EmailTemplate.EmailTemplateEntity", b =>
                {
                    b.Property<Guid>("EmailTemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmailAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmailTemplate")
                        .HasColumnType("int");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailTemplateId");

                    b.HasIndex("EmailAccountId");

                    b.HasIndex("EmailTemplateId");

                    b.ToTable("Commander_EmailTemplate", (string)null);

                    b.HasData(
                        new
                        {
                            EmailTemplateId = new Guid("8075ef16-0179-4bab-b1b0-0d616316af8b"),
                            Active = true,
                            Content = "",
                            EmailAccountId = new Guid("428ba167-51c8-422b-9248-0fa681e744a4"),
                            EmailName = "Aktywacja konta - JoyProfits.com",
                            EmailTemplate = 0,
                            SenderName = "JoyProfits - Earn with us",
                            Subject = "Rejestracja konta JoyProfits.com"
                        },
                        new
                        {
                            EmailTemplateId = new Guid("284d5a55-9e72-4bb8-9810-40f22d46daae"),
                            Active = true,
                            Content = "",
                            EmailAccountId = new Guid("428ba167-51c8-422b-9248-0fa681e744a4"),
                            EmailName = "Resetowanie hasła - JoyProfits.com",
                            EmailTemplate = 1,
                            SenderName = "JoyProfits - Earn with us",
                            Subject = "Resetowanie hasła JoyProfits.com"
                        },
                        new
                        {
                            EmailTemplateId = new Guid("bb4271c5-5b8b-4c22-84ac-214cdef19231"),
                            Active = true,
                            Content = "",
                            EmailAccountId = new Guid("428ba167-51c8-422b-9248-0fa681e744a4"),
                            EmailName = "Potwierdzenie otrzymania wiadomości - JoyProfits.com",
                            EmailTemplate = 5,
                            SenderName = "JoyProfits - Earn with us",
                            Subject = "Dziękujemy za kontakt z JoyProfits.com"
                        });
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.User.UserEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Commander_User", (string)null);
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.Email.EmailAttachedEntity", b =>
                {
                    b.HasOne("Jookli.Commander.Domain.Entites.Email.EmailEntity", "Email")
                        .WithMany("EmailAttacheds")
                        .HasForeignKey("EmailAttachedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Email");
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.Email.EmailEntity", b =>
                {
                    b.HasOne("Jookli.Commander.Domain.Entites.EmailAccount.EmailAccountEntity", "EmailAccount")
                        .WithMany("Emails")
                        .HasForeignKey("EmailAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailAccount");
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.EmailTemplate.EmailTemplateAttachedEntity", b =>
                {
                    b.HasOne("Jookli.Commander.Domain.Entites.EmailTemplate.EmailTemplateEntity", "EmailTemplate")
                        .WithMany("EmailTemplateAttacheds")
                        .HasForeignKey("EmailTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailTemplate");
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.EmailTemplate.EmailTemplateEntity", b =>
                {
                    b.HasOne("Jookli.Commander.Domain.Entites.EmailAccount.EmailAccountEntity", "EmailAccount")
                        .WithMany("EmailTemplates")
                        .HasForeignKey("EmailAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailAccount");
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.Email.EmailEntity", b =>
                {
                    b.Navigation("EmailAttacheds");
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.EmailAccount.EmailAccountEntity", b =>
                {
                    b.Navigation("EmailTemplates");

                    b.Navigation("Emails");
                });

            modelBuilder.Entity("Jookli.Commander.Domain.Entites.EmailTemplate.EmailTemplateEntity", b =>
                {
                    b.Navigation("EmailTemplateAttacheds");
                });
#pragma warning restore 612, 618
        }
    }
}
