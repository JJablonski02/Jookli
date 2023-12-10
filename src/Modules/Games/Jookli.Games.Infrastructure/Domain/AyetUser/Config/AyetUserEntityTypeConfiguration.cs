using Jookli.Games.Domain.Entities.AyeTStudios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Infrastructure.Domain.AyetUser.Config
{
    internal sealed class AyetUserEntityTypeConfiguration : IEntityTypeConfiguration<AyetUserEntity>
    {
        public void Configure(EntityTypeBuilder<AyetUserEntity> builder)
        {
            builder.ToTable("Games_AyetUsers");
            builder.HasKey(x => x.AyetUserId);
            builder.HasIndex(x => x.AyetUserId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.AyetUsers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
