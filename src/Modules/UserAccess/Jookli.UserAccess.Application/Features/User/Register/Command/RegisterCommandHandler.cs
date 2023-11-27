using Jookli.UserAccess.Application.Authentication;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.Address;
using Jookli.UserAccess.Domain.Entities.Location;
using Jookli.UserAccess.Domain.Entities.LoginAttempts;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Entities.User.Events;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Jookli.UserAccess.Domain.Entities.UserDetails;
using Jookli.UserAccess.Domain.Enums;
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
            var userEmail = await _userRepository.GetByUserEmailAsync(command.Email, cancellationToken);

            if (userEmail is not null)
            {
                throw new ArgumentException($"User with email: {command.Email} exists");
            }

            if(command.Password != command.ConfirmPassword)
            {
                throw new ArgumentException("Password and Confirm Password do not match");
            }

            var password = PasswordManager.HashPassword(command.Password);

            var user = new UserEntity()
            {
                UserId = Guid.NewGuid(),
                Email = command.Email,
                Password = password,
                CreationDate = DateTime.UtcNow,
                AccountStatus = Domain.Enums.AccountStatus.WaitingForConfirmation,
                RegistrationSource = Domain.Enums.RegistrationSource.Internal,
                PushNotifications = command.PushNotifications,
                IsDeleted = false,
                IsAccountBlocked = false,
                UserDetails = new UserDetailsEntity()
                {
                    UserDetailsId = Guid.NewGuid(),
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Gender = command.Gender,
                },
                DateOfLastActivity = DateTime.Now,
                DateOfLastActivityUtc= DateTime.UtcNow
            };

            user.AddDomainEvent(
                new NewUserRegisteredDomainEvent(
                    user.UserId, user.Email, user.Password, user.CreationDate, user.AccountStatus, user.RegistrationSource,
                    user.PushNotifications, user.IsDeleted, user.IsAccountBlocked, user.UserDetails.UserId, user.UserDetails.FirstName,
                    user.UserDetails.LastName, user.UserDetails.Gender, user.DateOfLastActivity, user.DateOfLastActivityUtc));

            await _userRepository.AddAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
