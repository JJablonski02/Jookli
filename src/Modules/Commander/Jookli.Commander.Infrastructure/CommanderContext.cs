using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure.Inbox;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using Jookli.Commander.Domain.Entites.Email;
using Jookli.Commander.Domain.Entites.EmailAccount;
using Jookli.Commander.Domain.Entites.EmailTemplate;
using Jookli.Commander.Domain.Entites.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Jookli.Commander.Infrastructure
{
    public class CommanderContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<InboxMessage> InboxMessage { get; set; }
        public DbSet<UserEntity> User {get; set;}    
        public DbSet<EmailTemplateEntity> EmailTemplate { get; set; }
        public DbSet<EmailAccountEntity> EmailAccount { get; set; }
        public DbSet<EmailEntity> Email { get; set;  }

        private readonly ILoggerFactory _logger;
        public CommanderContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
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
