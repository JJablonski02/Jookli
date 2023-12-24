using Jookli.BuildingBlocks.Application.Events;
using Jookli.UserAccess.Domain.Entities.Emails.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Email.SendAnonymousMessage.Notification
{
    public class SendAnonymousMessageNotification : DomainNotificationBase<AnonymousEmailMessageDomainEvent>
    {
        public SendAnonymousMessageNotification(AnonymousEmailMessageDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
