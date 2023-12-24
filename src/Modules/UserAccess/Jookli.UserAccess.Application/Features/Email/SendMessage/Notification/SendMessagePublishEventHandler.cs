using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Email.SendMessage.Notification
{
    public class SendMessagePublishEventHandler : INotificationHandler<SendMessageNotification>
    {
        private readonly IEventsBus _eventsBus;

        public SendMessagePublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }
        public async Task Handle(SendMessageNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new SendMessageIntegrationEvent(
                notification.Id,
                notification.DomainEvent.OccuredOn,
                notification.DomainEvent.EmailId,
                notification.DomainEvent.UserId,
                notification.DomainEvent.Message,
                notification.DomainEvent.ReceivedDate
                ));
        }
    }
}
