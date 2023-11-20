using Jookli.Games.Application.Configuration.Command;
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
        public Task<Unit> Handle(ProfileCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
