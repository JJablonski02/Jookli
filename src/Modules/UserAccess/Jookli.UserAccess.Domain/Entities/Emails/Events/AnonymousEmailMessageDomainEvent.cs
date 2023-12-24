using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Emails.Events
{
    public class AnonymousEmailMessageDomainEvent : DomainEventBase
    {
        public AnonymousEmailMessageDomainEvent(Guid emailId, string contactEmailAddress, string contactPhoneNumber, string message, string signature, DateTime receivedDate)
        {
            EmailId = emailId;
            ContactEmailAddress = contactEmailAddress;
            ContactPhoneNumber = contactPhoneNumber;
            Message = message;
            Signature = signature;
            ReceivedDate = receivedDate;
        }

        public Guid EmailId { get; set; }
        public string ContactEmailAddress { get; set; }
        public string? ContactPhoneNumber { get; set; }
        public string Message { get; set; }
        public string Signature { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
