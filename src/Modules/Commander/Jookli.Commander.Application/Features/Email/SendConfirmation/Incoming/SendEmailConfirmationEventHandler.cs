using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Application.Features.Email.SendConfirmation.Command;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.Email.SendConfirmation.Incoming
{
    internal class SendEmailConfirmationEventHandler : INotificationHandler<SendEmailConfirmationIntegrationEvent>
    {
        private readonly ICommandsScheduler _commandsScheulder;

        public SendEmailConfirmationEventHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheulder = commandsScheduler;
        }
        public async Task Handle(SendEmailConfirmationIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _commandsScheulder.EnqueueAsync(new SendConfirmationCommand(
                notification.Id,
                notification.UserId,
                notification.Email,
                notification.CallbackUrl,
                notification.FirstName,
                notification.LastName
                ));
        }
    }
}
