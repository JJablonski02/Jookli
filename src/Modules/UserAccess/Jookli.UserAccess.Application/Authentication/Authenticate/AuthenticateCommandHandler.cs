using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Entities.LoginAttempts;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Authentication.Authenticate
{
    public class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResult> Handle(AuthenticateCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserEmailAsync(command.Login, cancellationToken);

            if(user == null)
            {
                return new AuthenticationResult($"User with {command.Login} does not exist");
            }

            bool isPasswordCorrect = PasswordManager.VerifyHashedPassword(user.Password, command.Password);

            if(!isPasswordCorrect)
            {
                LoginAttemptEntity badLoginAttempt = new LoginAttemptEntity
                {
                    LoginAttemptId = Guid.NewGuid(),
                    UserId = user.UserId,
                    Email = command.Login,
                    Password = command.Password,
                    BadAuthorizationDate = DateTime.UtcNow,
                };
                user.LoginAttempts.Add(badLoginAttempt);

                return new AuthenticationResult("Email or password is incorrect");
            }

            if (user.IsDeleted)
            {
                LoginAttemptEntity badLoginAttempt = new LoginAttemptEntity
                {
                    LoginAttemptId = Guid.NewGuid(),
                    UserId = user.UserId,
                    Email = command.Login,
                    Password = command.Password,
                    BadAuthorizationDate = DateTime.UtcNow,
                };
                user.LoginAttempts.Add(badLoginAttempt);

                return new AuthenticationResult("This account has been deleted");
            }

            if (user.IsAccountBlocked)
            {
                LoginAttemptEntity badLoginAttempt = new LoginAttemptEntity
                {
                    LoginAttemptId = Guid.NewGuid(),
                    UserId = user.UserId,
                    Email = command.Login,
                    Password = command.Password,
                    BadAuthorizationDate = DateTime.UtcNow,
                };
                user.LoginAttempts.Add(badLoginAttempt);

                return new AuthenticationResult($"This account has been blocked from {user.AccountBlockedSince} to {user.AccountBlockedUntil}");
            }

            LoginAttemptEntity loginAttempt = new LoginAttemptEntity
            {
                LoginAttemptId = Guid.NewGuid(),
                UserId = user.UserId,
                Email = command.Login,
                Password = command.Password,
                SuccessfullAuthorizationDate = DateTime.UtcNow,
            };
            user.LoginAttempts.Add(loginAttempt);

            UserDTO userDTO = new UserDTO
            {
                UserId = user.UserId,
                Email = command.Login,
                IsDeleted = user.IsDeleted,
                IsAccountBlocked = user.IsAccountBlocked,
                Password = command.Password,
                Claims = new List<Claim>
                {
                    new Claim(CustomClaimTypes.Email, command.Login)
                }
            };

            return new AuthenticationResult(userDTO);
        }
    }
}
