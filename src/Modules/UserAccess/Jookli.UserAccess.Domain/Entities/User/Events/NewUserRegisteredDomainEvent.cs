using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class NewUserRegisteredDomainEvent : DomainEventBase
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public RegistrationSource RegistrationSource { get; set; }
        public bool PushNotifications { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAccountBlocked { get; set; }
        public Guid UserDetailsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfLastActivity { get; set; }
        public DateTime DateOfLastActivityUtc { get; set; }

        public NewUserRegisteredDomainEvent(
            Guid userId,
            string email,
            string passowrd,
            DateTime creationDate,
            AccountStatus accountStatus,
            RegistrationSource registrationSource,
            bool pushNotifications,
            bool isDeleted,
            bool isAccountBlocked,
            Guid userDetailsId,
            string firstName,
            string lastName,
            Gender gender,
            DateTime dateOfLastActivity,
            DateTime dateOfLastActivityUtc
            )
        {
            UserId = userId;
            Email = email;
            Password = passowrd;
            CreationDate = creationDate;
            this.AccountStatus = accountStatus;
            this.RegistrationSource = registrationSource;
            PushNotifications = pushNotifications;
            IsDeleted = isDeleted;
            IsAccountBlocked = isAccountBlocked;
            UserDetailsId = userDetailsId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfLastActivity = dateOfLastActivity;
            DateOfLastActivityUtc = dateOfLastActivityUtc;
        }

        public record Location
        {
            Guid UserId { get; set; }
            Guid LocationId { get; set; }
            bool IsLocationAllowed { get; set; }
            TimeSpan Interval { get; set; }
            List<LocationService> LocationServices { get; set; }
        }
        public record LocationService
        {
            Guid LocationId { get; set; }
            Guid LocationServiceId { get; set; }

            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string LocationName { get; set; }
            public DateTime TimeStamp { get; set; }
        }
        
    }
}
