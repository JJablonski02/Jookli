using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Domain.Interfaces
{
    internal interface IHasId
    {
        string Id { get; set; }
    }
}
