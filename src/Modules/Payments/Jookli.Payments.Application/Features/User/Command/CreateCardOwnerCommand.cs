using Jookli.Payments.Application.Configuration.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.User.Command
{
    public class CreateCardOwnerCommand : InternalCommandBase
    {
        internal Guid UserId { get; set; }
        internal string Email { get; set; }
        internal string FirstName { get; set; }
        internal string LastName { get; set; }

        [JsonConstructor]
        public CreateCardOwnerCommand(Guid Id, Guid userId, string email, string firstName, string lastName) : base(Id)
        { 
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
