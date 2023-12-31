﻿using Jookli.Payments.Domain.Entities.Stripe.Card;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Domain.Card.Config
{
    internal sealed class CardTypeConfiguration : IEntityTypeConfiguration<CardEntity>
    {
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            builder.ToTable("Payments_Card");

            builder.HasKey(x => x.CardId);
        }
    }
}
