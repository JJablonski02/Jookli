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
            var userEmail =await  _userRepository.GetByUserEmailAsync(command.Email, cancellationToken);

            if (userEmail is not null)
            {
                throw new ArgumentException($"User with email: {command.Email} exists");
            }

            var user = new UserEntity()
            {
                UserID = Guid.NewGuid(),
                Email = command.Email,
                Password = command.Password,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Gender = command.Gender
            };

            await _userRepository.AddUserAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
