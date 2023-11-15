using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure.Inbox
{
    public class InboxMessage
    {
        public Guid Id { get; set; }
        public DateTime OccuredOn { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime? ProcessedDate { get; set; }

        public InboxMessage(DateTime occuredOn, string type, string data)
        {
            this.Id = Guid.NewGuid();
            this.OccuredOn = occuredOn;
            this.Type = type;
            this.Data = data;
        }

        private InboxMessage() { }
    }
}
