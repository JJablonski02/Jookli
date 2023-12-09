using Jookli.BuildingBlocks.Application.Events;
using Jookli.UserAccess.Domain.Entities.User.Events;

namespace Jookli.UserAccess.Application.Features.User.Register.Notification
{
    public class SendEmailConfirmationNotification : DomainNotificationBase<SendEmailConfirmationDomainEvent>
    {
        public SendEmailConfirmationNotification(SendEmailConfirmationDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
