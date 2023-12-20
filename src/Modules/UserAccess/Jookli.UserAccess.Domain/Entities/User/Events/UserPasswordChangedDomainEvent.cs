using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class UserPasswordChangedDomainEvent : DomainEventBase
    {
        public UserPasswordChangedDomainEvent(Guid userId, string password)
        {
            UserId= userId;
            Password= password;
        }
        public Guid UserId { get; set; }
        public string Password { get; set; }
    }
}
