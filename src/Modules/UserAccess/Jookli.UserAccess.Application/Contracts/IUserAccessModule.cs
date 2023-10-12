
using MediatR;

namespace Jookli.UserAccess.Application.Contracts
{
    public interface IUserAccessModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync (ICommand command);
    }
}
