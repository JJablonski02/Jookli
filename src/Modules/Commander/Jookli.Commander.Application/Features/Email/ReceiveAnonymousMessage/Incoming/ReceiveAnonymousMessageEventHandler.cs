using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Application.Features.Email.ReceiveAnonymousMessage.Command;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.Email.ReceiveAnonymousMessage.Incoming
{
    public class ReceiveAnonymousMessageEventHandler : INotificationHandler<SendAnonymousMessageIntegrationEvent>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public ReceiveAnonymousMessageEventHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }
        public async Task Handle(SendAnonymousMessageIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _commandsScheduler.EnqueueAsync(new ReceiveAnonymousMessageCommand(
                notification.Id,
                notification.EmailId,
                notification.ContactEmailAddress,
                notification.ContactPhoneNumber,
                notification.Message,
                notification.Signature,
                notification.ReceivedDate));
        }
    }
}
