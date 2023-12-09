using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class SendEmailConfirmationDomainEvent : DomainEventBase
    {
        public SendEmailConfirmationDomainEvent(Guid userId, string emailAddress, string url)
        {
            UserId = userId;
            Email = emailAddress;
            Url = url;
        }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }
}
