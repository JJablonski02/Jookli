using Jookli.Application.Features.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Application.ServiceContracts
{
    public interface IMessageAdderService
    {
        Task<MessageResponse> AddMessage(MessageRequest? messageRequest);
    }
}
