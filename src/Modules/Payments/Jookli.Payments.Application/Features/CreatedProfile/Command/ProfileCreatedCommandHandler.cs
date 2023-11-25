using Jookli.Payments.Application.Configuration.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.CreatedProfile.Command
{
    internal class ProfileCreatedCommandHandler : ICommandHandler<ProfileCreatedCommand>
    {
        public Task<Unit> Handle(ProfileCreatedCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
