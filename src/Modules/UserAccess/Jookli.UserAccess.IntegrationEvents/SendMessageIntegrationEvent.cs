using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class SendMessageIntegrationEvent : IntegrationEvent
    {
        public SendMessageIntegrationEvent(Guid id, DateTime occuredOn, Guid emailId, Guid userId, string message, DateTime receivedDate) : base(id, occuredOn)
        {
            EmailId = emailId;
            UserId = userId;
            Message = message;
            ReceivedDate = receivedDate;
        }
        public Guid EmailId { get; }
        public Guid UserId { get; }
        public string Message { get; }
        public DateTime ReceivedDate { get; }
    }
}
