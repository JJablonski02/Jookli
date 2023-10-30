using Jookli.UserAccess.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.User
{
    internal class UserEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.UserID);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.FirstName)
                   .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .HasMaxLength(50);


            builder.Property(x => x.DateOfBirth)
                   .HasColumnType("date");

            builder.Property(x => x.PhoneNumber)
                   .IsRequired();

            builder.Property(x => x.Premium);

            builder.HasMany(x => x.MessagesReceived)
                   .WithOne();
        }
    }
}
