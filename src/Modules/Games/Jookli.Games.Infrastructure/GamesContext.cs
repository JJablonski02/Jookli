using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure.Inbox;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using Jookli.Games.Domain.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Jookli.Games.Infrastructure
{
    public class GamesContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<InboxMessage> InboxMessage { get; set; }
        private readonly ILoggerFactory _logger;
        public GamesContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
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
