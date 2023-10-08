
namespace Jookli.Application.ServiceContracts
{
    public interface IIdentityService
    {
        Task ExecuteCommandAsync<TRequest>(TRequest request);
    }
}
