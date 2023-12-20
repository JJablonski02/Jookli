using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class SendEmailConfirmationIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; }
        public string Email { get; }
        public string CallbackUrl { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public SendEmailConfirmationIntegrationEvent(Guid id, DateTime occuredOn, Guid userId, string email, string callbackUrl, string firstName, string lastName) : base(id, occuredOn)
        {
            UserId = userId;
            Email = email;
            CallbackUrl = callbackUrl;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
