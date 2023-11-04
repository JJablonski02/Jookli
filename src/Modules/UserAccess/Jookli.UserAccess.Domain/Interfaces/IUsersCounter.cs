using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Interfaces
{
    public interface IUsersCounter
    {
        int CountUsersWithLogin(string login);
    }
}
