using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Message
{
    public class MessageResponse
    {
        public Guid MessageId { get; set; }
        public DateTime MessageTime { get; set; }
        public int MessagePhoneNumber { get; set; }
        public string? MessageContent { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != typeof(MessageResponse))
            {
                return false;
            }
            MessageResponse messageResponse = (MessageResponse)obj;

            return MessageId == messageResponse.MessageId &&
                MessageTime == messageResponse.MessageTime &&
                MessagePhoneNumber == messageResponse.MessagePhoneNumber &&
                MessageContent == messageResponse.MessageContent;
        }
    }
}
