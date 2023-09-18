using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Domain.Entities.Message.RepositoryContract
{
    public interface IMessageRepository
    {
        /// <summary>
        /// Adds a message object to the data store
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns the message object after adding it to the table</returns>
        Task<MessageEntity> AddMessage(MessageEntity message);

        /// <summary>
        /// Returns message in the data store
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns>Returns message from table</returns>
        Task<MessageEntity> GetMessage(Guid messageID);
    }
}
