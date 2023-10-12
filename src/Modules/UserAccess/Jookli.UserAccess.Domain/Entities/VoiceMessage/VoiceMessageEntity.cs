using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.VoiceMessage
{
    public class VoiceMessageEntity
    {
        [Key]
        public Guid VoiceMessageId { get; set; }
        public DateTime VoiceMessageDateTime { get; set; }
        public int VoiceMessageLength { get; set; }
    }
}
