using Jookli.UserAccess.Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.Address.Config
{
    internal sealed class AddressEntityTypeConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("UserAccess_Address");

            builder.HasKey(x => x.AddressId);
            builder.HasOne(x => x.User)
                .WithOne(user => user.Address)
                .HasForeignKey<AddressEntity>(x => x.UserId);
        }
    }
}
