using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jookli.Payments.Infrastructure
{
    public class PaymentsContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        private readonly ILoggerFactory _logger;
        public PaymentsContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _logger = loggerFactory;
        }
    }
}
