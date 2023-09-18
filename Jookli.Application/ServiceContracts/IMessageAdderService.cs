using Jookli.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Application.ServiceContracts
{
    internal interface IMessageAdderService
    {
        Task<MessageResponse> AddMessage(MessageAddRequest? messageAddRequest);
    }
}
