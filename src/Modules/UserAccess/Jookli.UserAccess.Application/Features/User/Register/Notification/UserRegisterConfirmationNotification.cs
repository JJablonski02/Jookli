using Jookli.BuildingBlocks.Application.Events;
using Jookli.UserAccess.Domain.Entities.User.Events;

namespace Jookli.UserAccess.Application.Features.User.Register.Notification
{
    public class UserRegisterConfirmationNotification : DomainNotificationBase<NewUserRegisteredDomainEvent>
    {
        public UserRegisterConfirmationNotification(NewUserRegisteredDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
