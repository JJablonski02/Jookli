using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Application.ServiceContracts
{
    public interface IUserService
    {
        Task<IRequest> ExecuteCommandAsync<TRequest>(TRequest request);
    }
}
