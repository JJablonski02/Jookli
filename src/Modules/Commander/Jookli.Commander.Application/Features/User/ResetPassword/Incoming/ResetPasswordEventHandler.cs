using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Application.Features.User.ResetPassword.Command;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.User.ResetPassword.Incoming
{
    internal class ResetPasswordEventHandler : INotificationHandler<UserPasswordChangedIntegrationEvent>
    {
        private readonly ICommandsScheduler _commandsScheduler;
        public ResetPasswordEventHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }
        public async Task Handle(UserPasswordChangedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _commandsScheduler.EnqueueAsync(new ResetPasswordCommand(notification.Id, notification.UserId, notification.Password));
        }
    }
}
