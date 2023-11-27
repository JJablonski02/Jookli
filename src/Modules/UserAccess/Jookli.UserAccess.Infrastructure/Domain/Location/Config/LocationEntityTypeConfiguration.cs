using Jookli.UserAccess.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.Location.Config
{
    internal sealed class LocationEntityTypeConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.ToTable("UserAccess_Location");

            builder.HasKey(x => x.LocationId);

            builder.HasOne(x => x.User)
                .WithOne(user => user.Location)
                .HasForeignKey<LocationEntity>(e => e.UserId);
        }
    }
}
