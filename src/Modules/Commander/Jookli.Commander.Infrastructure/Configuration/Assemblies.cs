using Jookli.Commander.Application.Configuration.Command;
using System.Reflection;

namespace Jookli.Commander.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}
