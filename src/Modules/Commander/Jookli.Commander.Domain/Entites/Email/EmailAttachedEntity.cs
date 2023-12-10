using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.Email
{
    public class EmailAttachedEntity : Entity
    {
        public Guid EmailAttachedId { get; set; }
        public Guid EmailId { get; set; }
        public EmailEntity Email { get; set; }
        public string FilePath { get; set; }
        public string? Name { get; set; }
    }
}
