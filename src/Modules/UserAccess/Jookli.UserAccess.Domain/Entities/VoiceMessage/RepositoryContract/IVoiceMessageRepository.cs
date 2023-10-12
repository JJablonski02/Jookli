using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.VoiceMessage.RepositoryContract
{
    public interface IVoiceMessageRepository
    {
        Task AddVoiceMessageAsync(VoiceMessageEntity voiceMessage);
        Task<VoiceMessageEntity?> GetVoiceMessageByIdAsync(Guid voiceMessageId);
    }
}
