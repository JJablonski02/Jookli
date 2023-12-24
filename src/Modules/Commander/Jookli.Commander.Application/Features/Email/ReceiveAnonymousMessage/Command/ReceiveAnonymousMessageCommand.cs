using Jookli.Commander.Application.Configuration.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.Email.ReceiveAnonymousMessage.Command
{
    public class ReceiveAnonymousMessageCommand : InternalCommandBase
    {
        public ReceiveAnonymousMessageCommand(Guid id, Guid emailId, string contactEmailAddress, string contactPhoneNumber, string message, string signature, DateTime receivedDate) : base(id)
        {
            EmailId = emailId;
            ContactEmailAddress = contactEmailAddress;
            ContactPhoneNumber = contactPhoneNumber;
            Message = message;
            Signature = signature;
            ReceivedDate = receivedDate;
        }

        public Guid EmailId { get; }
        public string ContactEmailAddress { get; }
        public string? ContactPhoneNumber { get; }
        public string Message { get; }
        public string Signature { get; }
        public DateTime ReceivedDate { get; }
    }
}
