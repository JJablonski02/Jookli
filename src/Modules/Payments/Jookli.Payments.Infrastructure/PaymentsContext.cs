using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using Jookli.Payments.Domain.Entities.Card;
using Jookli.Payments.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jookli.Payments.Infrastructure
{
    public class PaymentsContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<CardEntity> Cards { get; set; }
        public DbSet<UserEntity> User { get; set; }

        private readonly ILoggerFactory _logger;
        public PaymentsContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _logger = loggerFactory;
        }
    }
}
