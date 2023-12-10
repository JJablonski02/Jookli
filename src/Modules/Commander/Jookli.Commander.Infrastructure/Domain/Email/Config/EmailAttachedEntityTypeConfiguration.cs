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
    internal sealed class EmailAttachedEntityTypeConfiguration : IEntityTypeConfiguration<EmailAttachedEntity>
    {
        public void Configure(EntityTypeBuilder<EmailAttachedEntity> builder)
        {
            builder.ToTable("Commander_EmailAttached");
            builder.HasKey(e => e.EmailAttachedId);
            builder.HasIndex(e => e.EmailAttachedId);

            builder.HasOne(e => e.Email)
                .WithMany(e => e.EmailAttacheds)
                .HasForeignKey(e => e.EmailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
