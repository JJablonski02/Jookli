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
                Subject = "Rejestracja konta - JoyProfits",
                Active = true,
                Content = "",
                EmailTemplate = Commander.Domain.Enums.EmailTemplateType.ConfirmAccount,
                EmailAccountId = Guid.Parse("428BA167-51C8-422B-9248-0FA681E744A4"),
                EmailName = "Aktywacja konta - JoyProfits.com"
            });

            builder.HasData(new EmailTemplateEntity
            {
                EmailTemplateId = Guid.Parse("284D5A55-9E72-4BB8-9810-40F22D46DAAE"),
                SenderName = "JoyProfits - Earn with us",
                Subject = "Hasło zresetowane - JoyProfits",
                Active = true,
                Content = "",
                EmailTemplate = Commander.Domain.Enums.EmailTemplateType.ResetPassword,
                EmailAccountId = Guid.Parse("428BA167-51C8-422B-9248-0FA681E744A4"),
                EmailName = "Resetowanie hasła - JoyProfits"
            });

            builder.HasData(new EmailTemplateEntity
            {
                EmailTemplateId = Guid.Parse("AAEFB675-15A3-4776-9CE9-0184EF577014"),
                SenderName = "JoyProfits - Earn with us",
                Subject = "Odzyskiwanie hasła - JoyProfits",
                EmailName = "Próba odzyskania hasła - JoyProfits",
                Active = true,
                Content = "",
                EmailTemplate = Commander.Domain.Enums.EmailTemplateType.RecoverPassword,
                EmailAccountId = Guid.Parse("428BA167-51C8-422B-9248-0FA681E744A4")
            });

            builder.HasData(new EmailTemplateEntity
            {
                EmailTemplateId = Guid.Parse("BB4271C5-5B8B-4C22-84AC-214CDEF19231"),
                SenderName = "JoyProfits - Earn with us",
                Subject = "Dziękujemy za kontakt z JoyProfits",
                Active = true,
                Content = "",
                EmailTemplate = Commander.Domain.Enums.EmailTemplateType.SendQuestion,
                EmailAccountId = Guid.Parse("428BA167-51C8-422B-9248-0FA681E744A4"),
                EmailName = "Potwierdzenie wysłania wiadomości - JoyProfits"
            });
        }
    }
}
