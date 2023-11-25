using Jookli.Games.Domain.Entities.Game;
using Jookli.Games.Domain.Entities.Game.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Infrastructure.Domain.Games.Respository
{
    internal class GameRepository : IGameRepository
    {
        private readonly GamesContext _gamesContext;
        public GameRepository(GamesContext gamesContext)
        {
            _gamesContext = gamesContext;
        }

        public async Task AddAsync(GameEntity gameEntity, CancellationToken cancellationToken)
        {
            await _gamesContext.Games.AddAsync(gameEntity, cancellationToken);
        }
    }
}
