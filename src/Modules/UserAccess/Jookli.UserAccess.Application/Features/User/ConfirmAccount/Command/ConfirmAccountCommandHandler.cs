using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.Token.Repository;
using Jookli.UserAccess.Domain.Entities.User.Events;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.ConfirmAccount.Command
{
    public class ConfirmAccountCommandHandler : ICommandHandler<ConfirmAccountCommand>
    {
        public readonly ITokenRepository _tokenRepository;
        public readonly IUserRepository _userRepository;

        public ConfirmAccountCommandHandler(ITokenRepository tokenRepository, IUserRepository userRepository)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(ConfirmAccountCommand command, CancellationToken cancellationToken)
        {
            var token = await _tokenRepository.GetByValue(command.TokenValue, cancellationToken);

            if(token == null)
            {
                throw new ArgumentException($"Token {command.TokenValue} does not exist");
            }

            if (!token.IsValid)
            {
                throw new ArgumentException($"Token {command.TokenValue} is not valid");
            }

            var user = await _userRepository.GetByUserIdAsync(token.UserId);

            if (user == null)
            {
                throw new ArgumentException($"User {token.UserId} was not found.");
            }


            if (token.ExpirationDate >  DateTime.UtcNow)
            {
                token.IsValid = false;
                user.AccountStatus = Domain.Enums.AccountStatus.ConfirmationExpired;

                throw new ArgumentException($"Token {command.TokenValue} expired");
            }

            user.AddDomainEvent(new UpdateUserAccountStatusDomainEvent(user.UserId, user.AccountStatus));

            user.AccountStatus = Domain.Enums.AccountStatus.Confirmed;
            token.IsValid = false;

            return Unit.Value;
        }
    }
}
