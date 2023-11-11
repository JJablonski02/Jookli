using Autofac;
using Jookli.Payments.Application.Contracts;
using Jookli.Payments.Infrastructure.Configuration;
using Jookli.Payments.Infrastructure.Configuration.Processing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure
{
    public class PaymentsModule : IPaymentsModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute<TResult>(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scoppe = PaymentsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scoppe.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}
