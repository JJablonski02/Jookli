using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Domain.Entities.User;
using Jookli.Payments.Domain.Entities.User.Repository;
using MediatR;
namespace Jookli.Payments.Application.Features.User.Command
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
            if(await _userRepository.ExistsAsync(command.UserId, cancellationToken))
            {
                return Unit.Value;
            }

            var user = new UserEntity()
            {
                UserId = command.UserId,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                IsDeleted = command.IsDeleted
            };

            await _userRepository.AddAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
