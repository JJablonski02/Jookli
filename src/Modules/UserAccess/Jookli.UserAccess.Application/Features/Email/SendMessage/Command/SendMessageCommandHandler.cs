using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.Emails;
using Jookli.UserAccess.Domain.Entities.Emails.Events;
using Jookli.UserAccess.Domain.Entities.Emails.Repository;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Email.SendMessage.Command
{
    public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IUserRepository _userRepository;
        public SendMessageCommandHandler(IEmailRepository emailRepository, IUserRepository userRepository)
        {
            _emailRepository = emailRepository;
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(SendMessageCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserIdAsync(command.UserId, cancellationToken);

            if(user == null)
            {
                throw new ArgumentException($"User with id {command.UserId} does not exist");
            }

            var email = new EmailEntity
            {
                EmailId = Guid.NewGuid(),
                UserId = command.UserId,
                Message = command.Message,
                ReceivedDate = DateTime.UtcNow,
            };

            email.AddDomainEvent(new EmailMessageDomainEvent(email.EmailId, email.UserId, email.Message, email.ReceivedDate));

            await _emailRepository.AddAsync(email, cancellationToken);

            return Unit.Value;
        }
    }
}
