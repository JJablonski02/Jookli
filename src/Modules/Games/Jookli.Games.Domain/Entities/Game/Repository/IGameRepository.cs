using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.Game.Repository
{
    public interface IGameRepository
    {
        Task AddAsync(GameEntity gameEntity, CancellationToken cancellationToken);
    }
}
