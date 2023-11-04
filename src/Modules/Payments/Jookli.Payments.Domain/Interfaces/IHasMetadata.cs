using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Domain.Interfaces
{
    public interface IHasMetadata
    {
        Dictionary<string, string> Metadata { get; set; }
    }
}
