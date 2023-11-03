using Jookli.Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Games.Infrastructure
{
    public class GamesContext : DbContext
    {
        public DbSet<GamesEntity> Games { get; set; }
    }
}
