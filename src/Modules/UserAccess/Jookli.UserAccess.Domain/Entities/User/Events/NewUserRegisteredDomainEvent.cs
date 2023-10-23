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
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DateOfLastActivity { get; }

        public NewUserRegisteredDomainEvent(
            Guid userId,
            string email,
            string passowrd,
            string firstName,
            string lastName,
            Gender gender,
            DateTime dateOfLastActivity,
            DateTime creationDate
            )
        {
            UserID = userId;
            Email = email;
            Password = passowrd;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfLastActivity = dateOfLastActivity;
            CreationDate = creationDate;
        }
    }
}
