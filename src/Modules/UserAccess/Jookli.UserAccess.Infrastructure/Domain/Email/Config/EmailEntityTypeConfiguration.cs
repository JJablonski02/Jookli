using Jookli.UserAccess.Domain.Entities.Emails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.Email.Config
{
    internal class EmailEntityTypeConfiguration : IEntityTypeConfiguration<EmailEntity>
    {
        public void Configure(EntityTypeBuilder<EmailEntity> builder)
        {
            builder.ToTable("UserAccess_Email");

            builder.HasKey(x => x.EmailId);
            builder.HasIndex(x => x.EmailId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.UserId);
        }
    }
}
