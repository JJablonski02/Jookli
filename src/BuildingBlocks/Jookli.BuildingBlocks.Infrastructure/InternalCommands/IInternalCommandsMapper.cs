using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure.InternalCommands
{
    public interface IInternalCommandsMapper
    {
        string GetName(Type type);

        Type GetType(string name);
    }
}
