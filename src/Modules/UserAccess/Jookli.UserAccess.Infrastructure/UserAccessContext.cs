using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Jookli.UserAccess.Domain.Entities.User;
using Microsoft.Extensions.Logging;
using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using System.Reflection;
using Jookli.BuildingBlocks.Infrastructure.Inbox;
using Jookli.UserAccess.Domain.Entities.Address;
using Jookli.UserAccess.Domain.Entities.Location;
using Jookli.UserAccess.Domain.Entities.UserDetails;
using Jookli.UserAccess.Domain.Entities.LoginAttempts;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Jookli.UserAccess.Domain.Entities.Token;
using Jookli.UserAccess.Domain.Entities.Emails;

namespace Jookli.UserAccess.Infrastructure
{
    public class UserAccessContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserDetailsEntity> UserDetails { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<LocationEntity> Location { get; set; }
        public DbSet<LocationServicesEntity> LocationServices { get; set; }
        public DbSet<LoginAttemptEntity> LoginAttempts { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<InboxMessage> InboxMessage { get; set; }
        public DbSet<TokenEntity> Token { get; set; }
        public DbSet<EmailEntity> Email { get; set; }
        public DbSet<AnonymousEmailEntity> AnonymousEmail { get; set; }


        private readonly ILoggerFactory _logger;
        public UserAccessContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
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
