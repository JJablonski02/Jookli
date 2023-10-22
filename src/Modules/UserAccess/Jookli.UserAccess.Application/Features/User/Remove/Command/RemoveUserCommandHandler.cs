using Jookli.BuildingBlocks.Application.Exceptions;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Remove.Command
{
    internal sealed class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RemoveUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserIdAsync(command.UserId);

            if(user is null)
            {
                throw new UserEntityException($"Error. User with id: {command.UserId} does not exist");
            }

            user.IsDeleted = true;

            return Unit.Value;
        }
    }
}
