using Jookli.UserAccess.Application.Features.Message;

namespace Jookli.UserAccess.Application.Contracts
{
    public interface IMessageGetterService
    {
        /// <summary>
        /// Get message by any content
        /// </summary>
        /// <param name="messageResponse"></param>
        /// <returns>Returns all found matching messages</returns>
        Task<MessageResponse> GetMessage(MessageRequest? messageRequest);

        /// <summary>
        /// Get message by Id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns>Returns message details</returns>
        Task<MessageResponse> GetMessageById(Guid messageId);

    }
}
