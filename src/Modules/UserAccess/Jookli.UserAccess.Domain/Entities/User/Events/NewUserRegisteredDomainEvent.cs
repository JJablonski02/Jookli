using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class NewUserRegisteredDomainEvent : DomainEventBase
    {
        public Guid Id { get; }
        public string Login { get; }
        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Name { get; }

        public DateTime RegisterDate { get; }

        public string ConfirmLink { get; }

        public NewUserRegisteredDomainEvent(
            Guid id,
            string login,
            string email,
            string firstName,
            string lastName,
            string name,
            DateTime registerDate,
            string confirmLink)
        {
            Id = id;
            Login = login;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            RegisterDate = registerDate;
            ConfirmLink = confirmLink;
        }
    }
}
