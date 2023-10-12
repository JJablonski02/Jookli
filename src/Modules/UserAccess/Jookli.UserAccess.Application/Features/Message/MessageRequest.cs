using Jookli.UserAccess.Domain.Entities.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Message
{
    public class MessageRequest
    {
        public Guid MessageId { get; set; }
        public DateTime MessageTime { get; set; }
        public int MessagePhoneNumber { get; set; }
        public string? MessageContent { get; set; }

        public MessageEntity ToMessage()
        {
            return new MessageEntity
            {
                MessageId = MessageId,
                MessageTime = MessageTime,
                MessagePhoneNumber = MessagePhoneNumber,
                MessageContent = MessageContent
            };
        }
    }
}
