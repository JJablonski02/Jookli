using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Jookli.UserAccess.Domain.Entities.User;
using Microsoft.Extensions.Logging;
using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using System.Reflection;
using Jookli.BuildingBlocks.Infrastructure.Inbox;

namespace Jookli.UserAccess.Infrastructure
{
    public class UserAccessContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<InboxMessage> InboxMessage { get; set; }


        private readonly ILoggerFactory _logger;
        public UserAccessContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _logger = loggerFactory;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("UserAccess");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
