using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Register.Notification
{
    public class SendEmailConfirmationPublishEventHandler : INotificationHandler<SendEmailConfirmationNotification>
    {
        private readonly IEventsBus _eventsBus;

        public SendEmailConfirmationPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public async Task Handle(SendEmailConfirmationNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new SendEmailConfirmationIntegrationEvent(
                notification.Id,
                notification.DomainEvent.OccuredOn,
                notification.DomainEvent.UserId,
                notification.DomainEvent.Email,
                notification.DomainEvent.Url,
                notification.DomainEvent.FirstName,
                notification.DomainEvent.LastName));
        }
    }
}
