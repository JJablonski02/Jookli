using Jookli.UserAccess.Application.Authentication;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.Address;
using Jookli.UserAccess.Domain.Entities.Location;
using Jookli.UserAccess.Domain.Entities.LoginAttempts;
using Jookli.UserAccess.Domain.Entities.Token;
using Jookli.UserAccess.Domain.Entities.Token.Events;
using Jookli.UserAccess.Domain.Entities.Token.Repository;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Entities.User.Events;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Jookli.UserAccess.Domain.Entities.UserDetails;
using Jookli.UserAccess.Domain.Enums;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Jookli.UserAccess.Application.Features.User.Register.Command
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public RegisterCommandHandler(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository= userRepository;
            _tokenRepository= tokenRepository;
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

            if(!Enum.IsDefined(typeof(RegistrationSource), command.RegistrationSource))
            {
                throw new ArgumentException("Registration source is invalid.");
            }

            var password = PasswordManager.HashPassword(command.Password);
            var user = new UserEntity()
            {
                UserId = Guid.NewGuid(),
                Email = command.Email,
                Password = password,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Gender = command.Gender,
                CreationDate = DateTime.UtcNow,
                AccountStatus = Domain.Enums.AccountStatus.WaitingForConfirmation,
                RegistrationSource = (RegistrationSource)Enum.ToObject(typeof(RegistrationSource), command.RegistrationSource),
                PushNotifications = command.PushNotifications,
                IsDeleted = false,
                IsAccountBlocked = false,
                DateOfLastActivity = DateTime.Now,
                DateOfLastActivityUtc= DateTime.UtcNow,
            };

            var token = new TokenEntity()
            {
                TokenId = Guid.NewGuid(),
                UserId = user.UserId,
                CreationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddHours(24),
                Metadata = "User confirmation token via email.",
                IsValid = true,
                TokenValue = TokenCryptography.sha256(Guid.NewGuid().ToString())
            };

            string callbackUrl = $"joyprofits.com/ConfirmAccount?token={token.TokenValue}";

            user.AddDomainEvent(
                new NewUserRegisteredDomainEvent(
                    user.UserId, user.Email, user.Password, user.FirstName, user.LastName, 
                    user.Gender, user.CreationDate, user.AccountStatus, user.RegistrationSource,
                    user.PushNotifications, user.IsDeleted, user.IsAccountBlocked, user.DateOfLastActivity, 
                    user.DateOfLastActivityUtc));

            token.AddDomainEvent(new TokenCreatedDomainEvent(user.UserId, TokenPurpose.ConfirmAccount));

            user.AddDomainEvent(
                new SendEmailConfirmationDomainEvent(user.UserId, user.Email, callbackUrl, user.FirstName, user.LastName));


            await _userRepository.AddAsync(user, cancellationToken);
            await _tokenRepository.AddAsync(token, cancellationToken);

            return Unit.Value;
        }
    }
}
