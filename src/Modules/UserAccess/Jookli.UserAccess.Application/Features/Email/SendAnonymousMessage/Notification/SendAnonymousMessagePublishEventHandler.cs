using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;

namespace Jookli.UserAccess.Application.Features.Email.SendAnonymousMessage.Notification
{
    public class SendAnonymousMessagePublishEventHandler : INotificationHandler<SendAnonymousMessageNotification>
    {
        private readonly IEventsBus _eventsBus;

        public SendAnonymousMessagePublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }
        public async Task Handle(SendAnonymousMessageNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new SendAnonymousMessageIntegrationEvent(
                notification.Id, 
                notification.DomainEvent.OccuredOn,
                notification.DomainEvent.EmailId,
                notification.DomainEvent.ContactEmailAddress,
                notification.DomainEvent.ContactPhoneNumber,
                notification.DomainEvent.Message,
                notification.DomainEvent.Signature,
                notification.DomainEvent.ReceivedDate));
        }
    }
}
