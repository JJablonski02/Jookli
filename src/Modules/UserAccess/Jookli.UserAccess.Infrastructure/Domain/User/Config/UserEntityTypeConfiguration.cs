using Jookli.UserAccess.Domain.Entities.Address;
using Jookli.UserAccess.Domain.Entities.Location;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Entities.UserDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.User.Config
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("UserAccess_User");

            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.UserId);

            builder.HasOne(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey<AddressEntity>(x => x.UserId);

            builder.HasOne(x => x.UserDetails)
                .WithOne(x => x.User)
                .HasForeignKey<UserDetailsEntity>(x => x.UserId);

            builder.HasMany(x => x.UsersDevice)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.LoginAttempts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Location)
                .WithOne(x => x.User)
                .HasForeignKey<LocationEntity>(x => x.UserId);
        }
    }
}
