using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Entities.VoiceMessage;
using Jookli.UserAccess.Domain.Entities.Message;
using Microsoft.Extensions.Logging;

namespace Jookli.UserAccess.Infrastructure.Data
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
