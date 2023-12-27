using Autofac;
using Jookli.Administrator.Application.Contracts;
using Jookli.Administrator.Infrastructure.Configuration;
using MediatR;


namespace Jookli.Administrator.Infrastructure.Configuration.Processing
{
    internal static class CommandsExecutor
    {
        internal static async Task Execute(ICommand command)
        {
            using (var scope = AdministratorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }
        internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = AdministratorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}
