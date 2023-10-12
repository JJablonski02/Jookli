using Jookli.UserAccess.Application.Features.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Contracts
{
    public interface IMessageAdderService
    {
        Task<MessageResponse> AddMessage(MessageRequest? messageRequest);
    }
}
