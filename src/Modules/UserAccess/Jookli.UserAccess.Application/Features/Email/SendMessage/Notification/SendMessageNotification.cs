using Jookli.BuildingBlocks.Application.Events;
using Jookli.UserAccess.Domain.Entities.Emails.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Email.SendMessage.Notification
{
    public class SendMessageNotification : DomainNotificationBase<EmailMessageDomainEvent>
    {
        public SendMessageNotification(EmailMessageDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
