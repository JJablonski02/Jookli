﻿using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.Domain.Entities.User.Events;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Remove.Notification
{
    public class UserRemovedPublishEventHandler : INotificationHandler<UserRemovedNotification>
    {
        private readonly IEventsBus _eventsBus;

        public UserRemovedPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public async Task Handle(UserRemovedNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new UserRemovedIntegrationEvent(
                notification.Id,
                notification.DomainEvent.OccuredOn,
                notification.DomainEvent.UserId));
        }
    }
}
