using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class UserPasswordChangedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public UserPasswordChangedIntegrationEvent(Guid id, DateTime occuredOn, Guid userId, string password) : base(id, occuredOn)
        {
            UserId = userId;
            Password = password;
        }
    }
}
