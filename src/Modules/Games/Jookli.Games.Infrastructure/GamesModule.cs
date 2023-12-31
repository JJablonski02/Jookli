﻿using Autofac;
using Jookli.Games.Application.Contracts;
using Jookli.Games.Infrastructure.Configuration;
using Jookli.Games.Infrastructure.Configuration.Processing;
using MediatR;

namespace Jookli.Games.Infrastructure
{
    public class GamesModule : IGamesModule
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
            using (var scope = GamesCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}
