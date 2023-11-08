using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Domain.Entities.User;
using Jookli.Payments.Domain.Entities.User.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.User.Command
{
    internal class CreateCardOwnerCommandHandler : ICommandHandler<CreateCardOwnerCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateCardOwnerCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateCardOwnerCommand command, CancellationToken cancellationToken)
        {
            var user = new UserEntity()
            {
                UserId = command.UserId,
                FirstName= command.FirstName,
                LastName= command.LastName,
                Email= command.Email,
            };
            await _userRepository.AddAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
