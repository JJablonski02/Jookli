using Jookli.Games.Application.Configuration.Command;
using Jookli.Games.Domain.Entities.User;
using Jookli.Games.Domain.Entities.User.Events;
using Jookli.Games.Domain.Entities.User.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.User.Command
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
        
        public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.ExistsAsync(command.UserId, cancellationToken))
            {
                return Unit.Value;
            }

            var user = new UserEntity
            {
                UserId = command.UserId,
                IsDeleted = false,
                FirstName = command.FirstName,
                LastName = command.LastName,
            };

            await _userRepository.AddAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
