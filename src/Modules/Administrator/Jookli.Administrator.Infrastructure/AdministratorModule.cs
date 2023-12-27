using Autofac;
using Jookli.Administrator.Application.Contracts;
using Jookli.Administrator.Infrastructure.Configuration;
using Jookli.Administrator.Infrastructure.Configuration.Processing;
using MediatR;

namespace Jookli.Games.Infrastructure
{
    public class AdministratorModule : IAdministratorModule
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
            using (var scope = AdministratorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}
