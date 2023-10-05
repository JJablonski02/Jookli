using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Domain.Entities.VoiceMessage
{
    public class VoiceMessageEntity
    {
        public Guid VoiceMessageId { get; set; }
        public DateTime VoiceMessageDateTime { get; set; }
        public decimal VoiceMessageLength { get; set; }
    }
}
