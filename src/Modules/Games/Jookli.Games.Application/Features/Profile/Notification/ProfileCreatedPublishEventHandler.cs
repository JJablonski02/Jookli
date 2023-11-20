using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.Games.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.Profile.Notification
{
    internal class ProfileCreatedPublishEventHandler : INotificationHandler<ProfileCreatedNotification>
    {
        private readonly IEventsBus _eventsBus;
        public ProfileCreatedPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public async Task Handle(ProfileCreatedNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new ProfileCreatedIntegrationEvent(
                notification.DomainEvent.Id,
                notification.DomainEvent.OccuredOn,
                notification.DomainEvent.ProfileId
                ));
        }
    }
}
