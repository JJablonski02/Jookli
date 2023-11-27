using Jookli.BuildingBlocks.Application.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Configuration.Outbox
{
    //internal class OutboxMessageGlobalTypeConfiguration : IEntityTypeConfiguration<OutboxMessage>
    //{
    //    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    //    {
    //        builder.ToTable("OutboxMessagesGlobal");
    //        builder.HasKey(x => x.Id);
    //        builder.Property(x => x.Id).ValueGeneratedNever();
    //    }
    //}
}
