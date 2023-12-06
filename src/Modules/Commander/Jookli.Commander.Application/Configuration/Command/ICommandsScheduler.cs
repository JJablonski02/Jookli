using Jookli.Commander.Application.Contracts;

namespace Jookli.Commander.Application.Configuration.Command
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}
