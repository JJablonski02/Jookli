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
    internal sealed class EmailTemplateAttachedTypeConfiguration : IEntityTypeConfiguration<EmailTemplateAttachedEntity>
    {
        public void Configure(EntityTypeBuilder<EmailTemplateAttachedEntity> builder)
        {
            builder.ToTable("Commander_EmailTemplateAttached");
            builder.HasKey(e => e.EmailTemplateAttachedId);
            builder.HasIndex(e => e.EmailTemplateAttachedId);

            builder.HasOne(e => e.EmailTemplate)
                .WithMany(e => e.EmailTemplateAttacheds)
                .HasForeignKey(e => e.EmailTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
