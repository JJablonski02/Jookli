using Jookli.UserAccess.Application.Authentication;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.Token;
using Jookli.UserAccess.Domain.Entities.Token.Repository;
using Jookli.UserAccess.Domain.Entities.User.Events;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.RecoverPassword.Command
{
    internal class SendRecoverPasswordCommandHandler : ICommandHandler<SendRecoverPasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        public SendRecoverPasswordCommandHandler(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<Unit> Handle(SendRecoverPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserEmailAsync(command.Email);

            if (user == null)
            {
                throw new ArgumentException($"User with {command.Email} does not exist");
            }

            var token = new TokenEntity()
            {
                TokenId = Guid.NewGuid(),
                UserId = user.UserId,
                CreationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMinutes(20),
                Metadata = "User confirmation token via email.",
                IsValid = true,
                TokenValue = TokenCryptography.sha256(Guid.NewGuid().ToString())
            };
            string uri = $"joyprofits.com/RecoverPassword?token={token.TokenValue}";

            token.AddDomainEvent(new SendRecoverPasswordDomainEvent(user.UserId, uri.ToString()));

            await _tokenRepository.AddAsync(token, cancellationToken);
            
            return Unit.Value;
        }
    }
}
