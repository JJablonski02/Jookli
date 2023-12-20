using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Domain.Entites.User;
using Jookli.Commander.Domain.Entites.User.Events;
using Jookli.Commander.Domain.Entites.User.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.User.Create.Command
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new UserEntity
            {
                UserId = command.UserId,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                IsDeleted = command.IsDeleted,
            };

            user.AddDomainEvent(new CreateUserDomainEvent(user.UserId));

            await _userRepository.AddAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
