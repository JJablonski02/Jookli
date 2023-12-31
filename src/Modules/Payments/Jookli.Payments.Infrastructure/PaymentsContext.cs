﻿using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure.Inbox;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using Jookli.Payments.Domain.Entities.Stripe.Card;
using Jookli.Payments.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Jookli.Payments.Infrastructure
{
    public class PaymentsContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<InboxMessage> InboxMessage { get; set; }
        public DbSet<CardEntity> Cards { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        private readonly ILoggerFactory _logger;
        public PaymentsContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _logger = loggerFactory;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
