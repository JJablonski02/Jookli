using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.ConfirmAccount.Notification
{
    public class ConfirmAccountPublishEventHandler : INotificationHandler<ConfirmAccountNotification>
    {
        public readonly IEventsBus _eventsBus;

        public ConfirmAccountPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus; 
        }
        public async Task Handle(ConfirmAccountNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new UpdateUserAccountStatusIntegrationEvent(
                notification.Id, 
                notification.DomainEvent.OccuredOn, 
                notification.DomainEvent.UserId, 
                notification.DomainEvent.AccStatus));
        }
    }
}
