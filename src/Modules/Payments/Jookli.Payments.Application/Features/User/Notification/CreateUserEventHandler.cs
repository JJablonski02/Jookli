﻿using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Application.Features.User.Command;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.User.Notification
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

            await _commandsScheduler.EnqueueAsync(
                new CreateCardOwnerCommand(
                    Guid.NewGuid(),
                    notification.UserId,
                    notification.Email,
                    notification.FirstName,
                    notification.LastName
                    ));

        }
    }
}
