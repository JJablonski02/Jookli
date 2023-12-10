using Jookli.Games.Domain.Entities.TapJoy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Infrastructure.Domain.TapJoyUser.Config
{
    internal sealed class TapJoyUserTypeConfiguration : IEntityTypeConfiguration<TapJoyUserEntity>
    {
        public void Configure(EntityTypeBuilder<TapJoyUserEntity> builder)
        {
            builder.ToTable("Games_TapJoyUsers");

            builder.HasKey(x => x.TapJoyUserId);
            builder.HasIndex(x => x.TapJoyUserId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.TapJoyUsers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
