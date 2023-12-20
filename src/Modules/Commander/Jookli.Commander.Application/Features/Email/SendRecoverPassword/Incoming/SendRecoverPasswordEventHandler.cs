using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Application.Features.Email.SendRecoverPassword.Command;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.Email.SendRecoverPassword.Incoming
{
    internal class RecoverPasswordEventHandler : INotificationHandler<UserRecoverPasswordIntegrationEvent>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public RecoverPasswordEventHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(UserRecoverPasswordIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _commandsScheduler.EnqueueAsync(new SendRecoverPasswordCommand(
                notification.Id, notification.UserId,
                notification.CallbackUrl));
        }
    }
}
