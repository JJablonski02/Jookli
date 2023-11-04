using Jookli.Payments.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Configuration.Command
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}
