using Jookli.Application.DTO;

namespace Jookli.Application.ServiceContracts
{
    public interface IMessageGetterService
    {
        /// <summary>
        /// Get message by any content
        /// </summary>
        /// <param name="messageResponse"></param>
        /// <returns>Returns all found matching messages</returns>
        Task<MessageRequest> GetMessage(MessageResponse? messageResponse);

        /// <summary>
        /// Get message by Id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns>Returns message details</returns>
        Task<MessageRequest> GetMessageById(Guid messageId);

    }
}
