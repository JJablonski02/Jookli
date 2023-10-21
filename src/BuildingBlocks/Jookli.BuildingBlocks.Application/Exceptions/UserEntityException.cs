using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Application.Exceptions
{
    public class UserEntityException : Exception
    {
        public UserEntityException(string message) : base(message)
        {
        }
    }
}
