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
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime? ProcessedDate { get; set; }

        public InboxMessage(Guid id, string type, string data, DateTime? processedDate)
        {
            Id = id;
            Type = type;
            Data = data;
            ProcessedDate = processedDate;
        }

        private InboxMessage() { }
    }
}
