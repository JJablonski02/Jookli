using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}
