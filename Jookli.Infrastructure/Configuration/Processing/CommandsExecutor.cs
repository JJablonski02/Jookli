using Autofac;
using MediatR;


namespace Jookli.Infrastructure.Configuration.Processing
{
    internal static class CommandsExecutor
    {
        internal static async Task Execute(IRequest request)
        {
            using (var scope = UserCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(request);
            }
        }
    }
}
