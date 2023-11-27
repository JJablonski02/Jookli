using Jookli.UserAccess.Domain.Entities.LoginAttempts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.LoginAttempts.Config
{
    internal sealed class LoginAttemptEntityTypeConfiguration : IEntityTypeConfiguration<LoginAttemptEntity>
    {
        public void Configure(EntityTypeBuilder<LoginAttemptEntity> builder)
        {
            builder.ToTable("UserAccess_LoginAttempts");

            builder.HasKey(t => t.LoginAttemptId);

            builder.HasOne(user => user.User)
                .WithMany(o => o.LoginAttempts)
                .HasForeignKey(x => x.UserId);
        }
    }
}
