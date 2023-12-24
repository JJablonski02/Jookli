using Jookli.UserAccess.Domain.Entities.Emails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jookli.UserAccess.Infrastructure.Domain.Email.Config
{
    internal class AnonymousEmailEntityTypeConfiguration : IEntityTypeConfiguration<AnonymousEmailEntity>
    {
        public void Configure(EntityTypeBuilder<AnonymousEmailEntity> builder)
        {
            builder.ToTable("UserAccess_AnonymousEmail");

            builder.HasKey(x => x.EmailId);
            builder.HasIndex(x => x.EmailId);
        }
    }
}
