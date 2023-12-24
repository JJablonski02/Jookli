using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Emails.Events
{
    public class EmailMessageDomainEvent : DomainEventBase
    {
        public EmailMessageDomainEvent(Guid emailId, Guid userId, string message, DateTime receivedDate)
        {
            EmailId = emailId;
            UserId = userId;
            Message = message;
            ReceivedDate = receivedDate;
        }
        public Guid EmailId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
