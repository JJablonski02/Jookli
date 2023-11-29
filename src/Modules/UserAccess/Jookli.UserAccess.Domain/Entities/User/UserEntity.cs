using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Entities.Address;
using Jookli.UserAccess.Domain.Entities.Location;
using Jookli.UserAccess.Domain.Entities.LoginAttempts;
using Jookli.UserAccess.Domain.Entities.UserDetails;
using Jookli.UserAccess.Domain.Enums;

namespace Jookli.UserAccess.Domain.Entities.User
{
    public class UserEntity : Entity
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreationDate { get; set; }
        public AddressEntity Address { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public RegistrationSource RegistrationSource { get; set; }
        public UserDetailsEntity UserDetails { get; set; }
        public ICollection<LoginAttemptEntity> LoginAttempts { get; set; }
        public LocationEntity Location { get; set; }
        public DateTime DateOfLastActivity { get; set; }
        public DateTime DateOfLastActivityUtc { get; set; }
        public bool IsDeleted { get; set; }  
        public bool Premium { get; set; }
        public bool PushNotifications { get; set; }
        public bool IsAccountBlocked { get; set; }
        public DateTime? AccountBlockedSince { get; set; }
        public DateTime? AccountBlockedUntil { get; set; }
    }
}
