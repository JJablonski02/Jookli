
using MediatR;

namespace Jookli.Application.ServiceContracts
{
    public interface IIdentityService
    {
        Task ExecuteCommandAsync (IRequest request);
    }
}
