using Jookli.Commander.Domain.Entites.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Jookli.Commander.Infrastructure.Domain.User.Config
{
    internal sealed class UserTypeConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Commander_User");

            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.UserId);
        }
    }
}
