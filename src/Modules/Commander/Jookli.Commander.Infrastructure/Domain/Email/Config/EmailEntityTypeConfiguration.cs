using Jookli.Commander.Domain.Entites.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Domain.Email.Config
{
    internal sealed class EmailEntityTypeConfiguration : IEntityTypeConfiguration<EmailEntity>
    {
        public void Configure(EntityTypeBuilder<EmailEntity> builder)
        {
            builder.ToTable("Commander_Email");

            builder.HasKey(e => e.EmailId);
            builder.HasIndex(e => e.EmailId);

            builder.HasOne(e => e.EmailAccount)
                .WithMany(e => e.Emails)
                .HasForeignKey(e => e.EmailAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.EmailAttacheds)
                .WithOne(e => e.Email)
                .HasForeignKey(e => e.EmailAttachedId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
