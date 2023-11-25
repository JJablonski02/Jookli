using Jookli.Games.Application.Configuration.Command;
using Jookli.Games.Domain.Entities.Profile;
using Jookli.Games.Domain.Entities.Profile.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.Profile.Command
{
    internal class ProfileCommandHandler : ICommandHandler<ProfileCommand>
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileCommandHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<Unit> Handle(ProfileCommand command, CancellationToken cancellationToken)
        {
            var user = new ProfileEntity
            {
                ProfileId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                UpdatedAt = DateTime.Now,
            };

            await _profileRepository.AddAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
