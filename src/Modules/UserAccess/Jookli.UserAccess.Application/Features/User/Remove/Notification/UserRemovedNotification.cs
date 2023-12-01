using Jookli.BuildingBlocks.Application.Events;
using Jookli.UserAccess.Domain.Entities.User.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Remove.Notification
{
    public class UserRemovedNotification : DomainNotificationBase<UserRemovedDomainEvent>
    {
        public UserRemovedNotification(UserRemovedDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
