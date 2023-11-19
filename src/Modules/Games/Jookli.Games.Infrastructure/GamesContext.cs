using Jookli.Games.Domain.Entities.Game;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Games.Infrastructure
{
    public class GamesContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }
    }
}
