using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Jookli.Domain.Entities.User;
using Jookli.Domain.Entities.VoiceMessage;
using Jookli.Domain.Entities.Message;
using Microsoft.Extensions.Logging;

namespace Jookli.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILoggerFactory _logger;
        public ApplicationDbContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _logger = loggerFactory;
        }

        public ApplicationDbContext()
        {

        }

        public virtual DbSet<UserEntity> User { get; set; }
        public virtual DbSet<VoiceMessageEntity> VoiceMessage { get; set; }
        public virtual DbSet<MessageEntity> MessageEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
