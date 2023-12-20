using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.ResendEmailConfirmation.Notification
{
    public class ResendEmailConfirmationPublishEventHandler : INotificationHandler<ResendEmailConfirmationNotification>
    {
        private readonly IEventsBus _eventsBus;

        public ResendEmailConfirmationPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public async Task Handle(ResendEmailConfirmationNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new SendEmailConfirmationIntegrationEvent(
                notification.Id,
                notification.DomainEvent.OccuredOn,
                notification.DomainEvent.UserId,
                notification.DomainEvent.Email,
                notification.DomainEvent.CallbackUrl,
                notification.DomainEvent.FirstName,
                notification.DomainEvent.LastName));
        }
    }
}
