﻿using Autofac;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Infrastructure.Configuration;
using MediatR;


namespace Jookli.UserAccess.Infrastructure.Configuration.Processing
{
    internal static class CommandsExecutor
    {
        internal static async Task Execute(ICommand command)
        {
            using (var scope = UserAccessCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }
        internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = UserAccessCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}
