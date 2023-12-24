using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.Emails;
using Jookli.UserAccess.Domain.Entities.Emails.Events;
using Jookli.UserAccess.Domain.Entities.Emails.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Email.SendAnonymousMessage.Command
{
    public class SendAnonymousMessageCommandHandler : ICommandHandler<SendAnonymousMessageCommand>
    {
        private readonly IAnonymousEmailRepository _anonymousEmailRepository;

        public SendAnonymousMessageCommandHandler(IAnonymousEmailRepository anonymousEmailRepository)
        {
            _anonymousEmailRepository = anonymousEmailRepository;
        }
        public async Task<Unit> Handle(SendAnonymousMessageCommand command, CancellationToken cancellationToken)
        {
            var email = new AnonymousEmailEntity
            {
                EmailId = Guid.NewGuid(),
                ContactEmailAddress = command.ContactEmailAddress,
                ContactPhoneNumber = command.ContactPhoneNumber,
                Message = command.Message,
                Signature = command.Signature,
                ReceivedDate = DateTime.UtcNow,
            };

            email.AddDomainEvent(new AnonymousEmailMessageDomainEvent(
                email.EmailId,
                email.ContactEmailAddress,
                email.ContactPhoneNumber,
                email.Message,
                email.Signature,
                email.ReceivedDate
                ));

            await _anonymousEmailRepository.AddAsync(email, cancellationToken);

            return Unit.Value;
        }
    }
}
