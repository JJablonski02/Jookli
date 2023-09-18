using Jookli.Application.DTO;

namespace Jookli.Application.ServiceContracts
{
    public interface IMessageGetterService
    {
        Task<MessageRequest> GetMessage(MessageResponse? messageResponse);
    }
}
