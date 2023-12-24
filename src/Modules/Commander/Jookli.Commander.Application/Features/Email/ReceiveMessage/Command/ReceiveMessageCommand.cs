using Jookli.Commander.Application.Configuration.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.Email.ReceiveMessage.Command
{
    public class ReceiveMessageCommand : InternalCommandBase
    {
        public ReceiveMessageCommand(Guid id, Guid emailId, Guid userId, string message, DateTime receivedDate) : base(id)
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
