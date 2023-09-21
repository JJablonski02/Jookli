using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Application.DTO
{
    public class MessageResponse
    {
        public Guid MessageId { get; set; }
        public DateTime MessageTime { get; set; } 
        public int MessagePhoneNumber { get; set; }
        public string? MessageContent {  get; set; }

        public override bool Equals(object? obj)
        {
            if(obj.GetType() != typeof(MessageResponse))
            {
                return false;
            }
            MessageResponse messageResponse = (MessageResponse)obj;

            return this.MessageId == messageResponse.MessageId &&
                this.MessageTime == messageResponse.MessageTime &&
                this.MessagePhoneNumber == messageResponse.MessagePhoneNumber &&
                this.MessageContent == messageResponse.MessageContent;
        }
    }
}
