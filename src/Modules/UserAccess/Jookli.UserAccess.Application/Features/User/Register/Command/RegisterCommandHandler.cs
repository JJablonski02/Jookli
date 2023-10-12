using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using MediatR;

namespace Jookli.UserAccess.Application.Features.User.Register.Command
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<Unit> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var userEmail = _userRepository.GetByUserEmailAsync(command.Email);

            if (userEmail is not null)
            {
                throw new ArgumentException($"User with email: {command.Email} exists");
            }

            var user = new UserEntity()
            {
                UserID = Guid.NewGuid(),
                UserName = command.Username,
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email,
                Password = command.Password,
                PhoneNumber = command.PhoneNumber,
            };

            await _userRepository.AddUserAsync(user);

            return Unit.Value;
        }
    }
}
