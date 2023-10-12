﻿using Jookli.UserAccess.Application.Contracts;
using MediatR;

namespace Jookli.UserAccess.Application.Configuration.Command
{
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand> 
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}
