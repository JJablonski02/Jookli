using Autofac;
using Jookli.Games.Application.Contracts;
using Jookli.Games.Infrastructure.Configuration;
using MediatR;


namespace Jookli.Games.Infrastructure.Configuration.Processing
{
    internal static class CommandsExecutor
    {
        internal static async Task Execute(ICommand command)
        {
            using (var scope = GamesCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }
        internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = GamesCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}
