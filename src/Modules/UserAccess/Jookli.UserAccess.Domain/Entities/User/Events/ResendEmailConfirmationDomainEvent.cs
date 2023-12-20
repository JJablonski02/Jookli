using Jookli.BuildingBlocks.Domain;


namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class ResendEmailConfirmationDomainEvent : DomainEventBase
    {
        public ResendEmailConfirmationDomainEvent(Guid userId, string email, string callbackUrl, string firstName, string lastName)
        {
            UserId = userId;
            Email = email;
            CallbackUrl = callbackUrl;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string CallbackUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
