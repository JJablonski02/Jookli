using Jookli.Commander.Domain.Entites.EmailAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Domain.EmailAccount.Config
{
    internal sealed class EmailAccountTypeConfiguration : IEntityTypeConfiguration<EmailAccountEntity>
    {
        public void Configure(EntityTypeBuilder<EmailAccountEntity> builder)
        {
            builder.ToTable("Commander_EmailAccount");

            builder.HasMany(e => e.Emails)
                .WithOne(e => e.EmailAccount)
                .HasForeignKey(e => e.EmailAccountId)
                .OnDelete(DeleteBehavior.Cascade);
                

            builder.HasMany(e => e.EmailTemplates)
                .WithOne(e => e.EmailAccount)
                .HasForeignKey(e => e.EmailAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new EmailAccountEntity
            {
                EmailAccountId = Guid.Parse("691B04BD-E13F-4253-B18F-E976049D71A7"),
                Name = "Support",
                SmtpLogin = "support@joyprofits.com",
                SmtpPassword = "",
                SmtpServer = "",
                SmtpPort = 0,
            });

        }
    }
}
