using Jookli.UserAccess.Domain.Entities.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.Token.Config
{
    internal sealed class TokenEntityTypeConfiguration : IEntityTypeConfiguration<TokenEntity>
    {
        public void Configure(EntityTypeBuilder<TokenEntity> builder)
        {
            builder.ToTable("UserAccess_Tokens");

            builder.HasKey(x => x.TokenId);

            builder.HasOne(x => x.User)
                .WithMany(y => y.Token)
                .HasForeignKey(x => x.UserId);
        }
    }
}
