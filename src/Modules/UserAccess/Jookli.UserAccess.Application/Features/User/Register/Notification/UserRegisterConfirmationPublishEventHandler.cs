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
    public class UserRegisterConfirmationPublishEventHandler : INotificationHandler<UserRegisterConfirmationNotification>
    {
        private readonly IEventsBus _eventsBus;

        public UserRegisterConfirmationPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public async Task Handle(UserRegisterConfirmationNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new SendEmailConfirmationIntegrationEvent(notification.Id, notification.DomainEvent.OccuredOn));
        }
    }
}
