using Jookli.UserAccess.Domain.Entities.UsersDevice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.UsersDevice.Config
{
    public class UsersDeviceEntityTypeConfiguration : IEntityTypeConfiguration<UsersDeviceEntity>
    {
        public void Configure(EntityTypeBuilder<UsersDeviceEntity> builder)
        {
            builder.ToTable("UserAccess_UsersDevice");

            builder.HasKey(x => x.UsersDeviceId);
            builder.HasOne(x => x.User)
                .WithMany(x => x.UsersDevice)
                .HasForeignKey(x => x.UserId);
        }
    }
}
