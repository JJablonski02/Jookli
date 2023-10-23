using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Domain.UserRegistrations
{
    public class UserRegistrationId : TypeIdValueBase
    {
        public UserRegistrationId(Guid value) : base(value)
        {
        }
    }
}
