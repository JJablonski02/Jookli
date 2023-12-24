using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class SendAnonymousMessageIntegrationEvent : IntegrationEvent
    {
        public SendAnonymousMessageIntegrationEvent(Guid id, DateTime occuredOn, Guid emailId, 
            string contactEmailAddress, string? contactPhoneNumber, string message, string signature, DateTime receivedDate) : base(id, occuredOn)
        {
            EmailId = emailId;
            ContactEmailAddress = contactEmailAddress;
            ContactPhoneNumber = contactPhoneNumber;
            Message = message;
            Signature = signature;
        }
        public Guid EmailId { get; }
        public string ContactEmailAddress { get; }
        public string? ContactPhoneNumber { get; }
        public string Message { get; }
        public string Signature { get; }
        public DateTime ReceivedDate { get; }
    }
}
