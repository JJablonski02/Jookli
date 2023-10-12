using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Infrastructure.Configuration.Processing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure
{
    public class UserAccessModule : IUserAccessModule
    {
        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }
    }
}