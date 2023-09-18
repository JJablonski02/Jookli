using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Domain.Entities.Message
{
    public class MessageSent
    {
        public Guid MessageId { get; set; }
        public DateTime MessageTime { get; set; }
        public string? MessageContent { get; set; }
    }
}
