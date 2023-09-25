using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Domain.Entities.Message
{
    public class MessageEntity
    {
        [Key]
        public Guid MessageId { get; set; }
        public DateTime MessageTime { get; set; }
        public int MessagePhoneNumber { get; set; }
        public string? MessageContent { get; set; }
    }
}
