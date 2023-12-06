using Autofac;
using Jookli.Commander.Application.Contracts;
using Jookli.Commander.Infrastructure.Configuration;
using Jookli.Commander.Infrastructure.Configuration.Processing;
using MediatR;

namespace Jookli.Commander.Infrastructure
{
    public class CommanderModule : ICommanderModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = CommanderCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}
