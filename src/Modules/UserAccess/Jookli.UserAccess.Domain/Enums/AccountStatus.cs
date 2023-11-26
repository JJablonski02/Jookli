using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Enums
{
    public enum AccountStatus
    {
        NotConfirmed = 0,
        Confirmed = 1,
        WaitingForConfirmation = 2,
        ConfirmationExpired = 3,
    }
}
