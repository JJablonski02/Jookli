using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Emails
{
    public class AnonymousEmailEntity : Entity
    {
        public Guid EmailId { get; set; }
        public string? ContactPhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }
        public string Message { get; set; }
        public string Signature { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
