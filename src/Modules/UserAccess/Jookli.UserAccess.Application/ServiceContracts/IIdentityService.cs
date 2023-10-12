
using MediatR;

namespace Jookli.Application.ServiceContracts
{
    public interface IIdentityService
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync (ICommand command);
    }
}
