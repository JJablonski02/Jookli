using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.Email.Events
{
    public class SendRecoverPasswordDomainEvent : DomainEventBase
    {
        public Guid EmailId { get; set; }
        public SendRecoverPasswordDomainEvent(Guid emailId)
        {
            EmailId = emailId;
        }
    }
}
