using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.RecoverPassword.Notification
{
    public class SendRecoverPasswordPublishEventHandler : INotificationHandler<SendRecoverPasswordNotification>
    {
        private readonly IEventsBus _eventsBus;

        public SendRecoverPasswordPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public async Task Handle(SendRecoverPasswordNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new UserRecoverPasswordIntegrationEvent(
                notification.Id,
                notification.DomainEvent.OccuredOn,
                notification.DomainEvent.UserId,
                notification.DomainEvent.CallbackUrl));
        }
    }
}
