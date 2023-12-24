using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Emails
{
    public class EmailEntity : Entity
    {
        public Guid EmailId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTime ReceivedDate { get; set; }
        public UserEntity User { get; set; }
    }
}
