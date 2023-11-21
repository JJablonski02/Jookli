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
        private readonly IProfileRepository _profileRepository;
        public ProfileRepository(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task AddAsync(ProfileEntity profileEntity, CancellationToken cancellationToken)
        {
            await _profileRepository.AddAsync(profileEntity, cancellationToken);
        }
    }
}
