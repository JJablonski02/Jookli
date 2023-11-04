using Jookli.Payments.Application.Configuration.Command;
using System.Reflection;


namespace Jookli.Payments.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;

    }
}
