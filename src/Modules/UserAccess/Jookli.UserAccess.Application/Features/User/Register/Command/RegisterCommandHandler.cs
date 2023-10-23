using Jookli.UserAccess.Application.Authentication;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Entities.User.Events;
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
            var password = PasswordManager.HashPassword(command.Password);
            var userEmail = await _userRepository.GetByUserEmailAsync(command.Email, cancellationToken);

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
                Gender = command.Gender,
                CreationDate = command.CreationDate,
                DateOfLastActivity = DateTime.UtcNow
            };

            user.AddDomainEvent(new NewUserRegisteredDomainEvent(user.UserID, user.Email, user.Password, user.FirstName, user.LastName, user.Gender, user.CreationDate, user.DateOfLastActivity));

            await _userRepository.AddUserAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
