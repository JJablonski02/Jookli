using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;


namespace Jookli.UserAccess.Application.Features.User.ResetPassword.Notification
{
    public class ResetPasswordPublishEventHandler : INotificationHandler<ResetPasswordNotification>
    {
        private readonly IEventsBus _eventsBus;

        public ResetPasswordPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public async Task Handle(ResetPasswordNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new UserPasswordChangedIntegrationEvent(
                notification.Id,
                notification.DomainEvent.OccuredOn,
                notification.DomainEvent.UserId,
                notification.DomainEvent.Password));
        }
    }
}
