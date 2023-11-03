using Jookli.Games.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Infrastructure
{
    internal class GamesModule : IGamesModule
    {
        public Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteCommandAsync(ICommand command)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            throw new NotImplementedException();
        }
    }
}
