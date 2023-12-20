using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class SendRecoverPasswordDomainEvent : DomainEventBase
    {
        public SendRecoverPasswordDomainEvent(Guid userId, string callbackUrl)
        {
            UserId = userId;
            CallbackUrl = callbackUrl;
        }
        public Guid UserId { get; set; }
        public string CallbackUrl { get; set; }
    }
}
