using Jookli.Commander.Domain.Entites.EmailTemplate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Domain.EmailTemplate.Config
{
    internal sealed class EmailTemplateTypeConfiguration : IEntityTypeConfiguration<EmailTemplateEntity>
    {
        public void Configure(EntityTypeBuilder<EmailTemplateEntity> builder)
        {
            builder.ToTable("Commander_EmailTemplate");
            builder.HasKey(e => e.EmailTemplateId);
            builder.HasIndex(e => e.EmailTemplateId);

            builder.HasMany(e => e.EmailTemplateAttacheds)
                .WithOne(e => e.EmailTemplate)
                .HasForeignKey(e => e.EmailTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.EmailAccount)
                .WithMany(e => e.EmailTemplates)
                .HasForeignKey(e => e.EmailAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new EmailTemplateEntity
            {
                EmailTemplateId = Guid.Parse("8075EF16-0179-4BAB-B1B0-0D616316AF8B"),
                SenderName = "JoyProfits - Earn with us",
                Subject = "Rejestracja konta JoyProfits.com",
                Active = true,
                Content = "",
                EmailTemplate = Commander.Domain.Enums.EmailTemplateType.ConfirmAccount,
                EmailAccountId = Guid.Parse("75D772F5-9B6B-4634-B2EF-E544AE02102C"),
                EmailName = "Aktywacja konta - JoyProfits.com"
            });

            builder.HasData(new EmailTemplateEntity
            {
                EmailTemplateId = Guid.Parse("75D772F5-9B6B-4634-B2EF-E544AE02102C"),
                SenderName = "JoyProfits - Earn with us",
                Subject = "Resetowanie hasła JoyProfits.com",
                Active = true,
                Content = "",
                EmailTemplate = Commander.Domain.Enums.EmailTemplateType.RecoverPassword,
                EmailAccountId = Guid.Parse("75D772F5-9B6B-4634-B2EF-E544AE02102C"),
                EmailName = "Resetowanie hasła - JoyProfits.com"
            });

            builder.HasData(new EmailTemplateEntity
            {
                EmailTemplateId = Guid.Parse("BB4271C5-5B8B-4C22-84AC-214CDEF19231"),
                SenderName = "JoyProfits - Earn with us",
                Subject = "Dziękujemy za kontakt z JoyProfits.com",
                Active = true,
                Content = "",
                EmailTemplate = Commander.Domain.Enums.EmailTemplateType.SendQuestion,
                EmailAccountId = Guid.Parse("4AA53C7A-B208-4ADA-8340-B0D429BB7880"),
                EmailName = "Potwierdzenie otrzymania wiadomości - JoyProfits.com"
            });
        }
    }
}
