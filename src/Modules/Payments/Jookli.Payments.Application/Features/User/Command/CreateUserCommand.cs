using Jookli.Payments.Application.Configuration.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.User.Command
{
    internal class CreateUserCommand : InternalCommandBase
    {
        public CreateUserCommand(Guid Id, Guid userId, string email, string firstName, string lastName) : base(Id)
        {
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
