using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Entities.VoiceMessage;
using Jookli.UserAccess.Domain.Entities.Message;
using Microsoft.Extensions.Logging;
using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;

namespace Jookli.UserAccess.Infrastructure.Data
{
    public class UserAccessContext : DbContext
    {
        private readonly ILoggerFactory _logger;
        public UserAccessContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _logger = loggerFactory;
        }

        public virtual DbSet<UserEntity> User { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
