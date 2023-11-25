using Jookli.Games.Domain.Entities.Profile;
using Jookli.Games.Domain.Entities.Profile.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Infrastructure.Domain.Profile.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly GamesContext _gamesContext;
        public ProfileRepository(GamesContext gamesContext)
        {
            _gamesContext = gamesContext;
        }

        public async Task AddAsync(ProfileEntity profileEntity, CancellationToken cancellationToken)
        {
            await _gamesContext.Profile.AddAsync(profileEntity, cancellationToken);
        }
    }
}
