

using Jookli.BuildingBlocks.Application.Events;
using Jookli.UserAccess.Domain.Entities.User.Events;

namespace Jookli.UserAccess.Application.Features.User.ResetPassword.Notification
{
    public class ResetPasswordNotification : DomainNotificationBase<UserPasswordChangedDomainEvent>
    {
        public ResetPasswordNotification(UserPasswordChangedDomainEvent domainEvent, Guid id, Guid userId, string password) : base(domainEvent, id)
        {
        }
    }
}
