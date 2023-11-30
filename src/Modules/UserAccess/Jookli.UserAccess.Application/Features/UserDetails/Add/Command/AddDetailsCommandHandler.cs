using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.UserDetails.Add.Command
{
    internal class AddDetailsCommandHandler : ICommandHandler<AddDetailsCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddDetailsCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(AddDetailsCommand command, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetByUserIdAsync(command.UserId, cancellationToken);

            if(user == null)
            {
                throw new ArgumentException($"User with {command.UserId} doesn't exists.");
            }


        }
    }
}
