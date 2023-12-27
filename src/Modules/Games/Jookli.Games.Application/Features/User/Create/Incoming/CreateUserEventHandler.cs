using Jookli.Games.Application.Configuration.Command;
using Jookli.Games.Application.Features.User.Create.Command;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.User.Create.Incoming
{
    internal class CreateUserEventHandler : INotificationHandler<NewUserRegisteredIntegrationEvent>
    {
        private readonly ICommandsScheduler _commandsScheduler;
        public CreateUserEventHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }
        public async Task Handle(NewUserRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _commandsScheduler.EnqueueAsync(new CreateUserCommand(
                notification.Id,
                notification.UserId,
                notification.Email,
                notification.FirstName,
                notification.LastName,
                notification.IsDeleted
                ));
        }
    }
}
