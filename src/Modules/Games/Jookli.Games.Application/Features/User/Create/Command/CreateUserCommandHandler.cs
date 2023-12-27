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

namespace Jookli.Games.Application.Features.User.Create.Command
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
            var exists = await _userRepository.ExistsAsync(command.UserId, cancellationToken);

            if (exists is true)
            {
                throw new ArgumentException($"User with id {command.UserId} exists");
            }

            string id = GenerateRandom();

            var user = new UserEntity
            {
                UserId = command.UserId,
                UserGamesId = id,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                IsDeleted = false,
            };

            await _userRepository.AddAsync(user, cancellationToken);

            return Unit.Value;
        }

        private static string GenerateRandom()
        {
            Random random = new Random();

            long randomNumber = random.NextInt64(0, 10000000000);

            string id = randomNumber.ToString("D10");

            return id;
        }
    }
}
