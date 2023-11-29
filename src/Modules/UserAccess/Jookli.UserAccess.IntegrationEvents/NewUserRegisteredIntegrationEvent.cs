using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class NewUserRegisteredIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public bool IsDeleted { get; }

        public NewUserRegisteredIntegrationEvent(Guid id, DateTime occurredOn, Guid userId, string email, string firstName, string lastName, bool isDeleted)
            : base(id, occurredOn)
        {
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsDeleted = isDeleted;
        }
    }
}
