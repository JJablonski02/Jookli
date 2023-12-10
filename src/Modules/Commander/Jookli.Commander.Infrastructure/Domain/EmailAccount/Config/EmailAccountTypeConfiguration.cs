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
            builder.HasKey(x => x.EmailAccountId);
            builder.HasIndex(x => x.EmailAccountId); 

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
                EmailAccountId = Guid.Parse("428BA167-51C8-422B-9248-0FA681E744A4"),
                Name = "Support",
                SmtpLogin = "support@joyprofits.com",
                SmtpPassword = "b_DPKkOK",
                SmtpServer = "serwer2377612.home.pl ",
                SmtpPort = 587,
            });

        }
    }
}
