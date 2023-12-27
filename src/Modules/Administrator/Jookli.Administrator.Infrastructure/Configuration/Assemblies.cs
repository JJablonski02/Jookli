using Jookli.Administrator.Application.Configuration.Command;
using System.Reflection;

namespace Jookli.Administrator.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}
