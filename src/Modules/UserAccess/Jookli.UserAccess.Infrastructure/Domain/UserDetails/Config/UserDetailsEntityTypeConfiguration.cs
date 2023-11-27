using Jookli.UserAccess.Domain.Entities.UserDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.UserDetails.Config
{
    internal sealed class UserDetailsEntityTypeConfiguration : IEntityTypeConfiguration<UserDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<UserDetailsEntity> builder)
        {
            builder.ToTable("UserAccess_UserDetails");

            builder.HasKey(x => x.UserDetailsId);
            builder.HasOne(x => x.User)
                .WithOne(x => x.UserDetails)
                .HasForeignKey<UserDetailsEntity>(t => t.UserId);
        }
    }
}
