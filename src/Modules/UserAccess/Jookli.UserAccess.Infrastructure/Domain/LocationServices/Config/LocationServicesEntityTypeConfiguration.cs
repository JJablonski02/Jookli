using Jookli.UserAccess.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.LocationServices.Config
{
    internal sealed class LocationServicesEntityTypeConfiguration : IEntityTypeConfiguration<LocationServicesEntity>
    {
        public void Configure(EntityTypeBuilder<LocationServicesEntity> builder)
        {
            builder.ToTable("UserAccess_LocationServices");
            builder.HasKey(x => x.LocationServiceId);

            builder.HasOne(t => t.Location)
                .WithMany(location => location.Services)
                .HasForeignKey(t => t.LocationId);
        }
    }
}
