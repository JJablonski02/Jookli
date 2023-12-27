using Jookli.Administrator.Application.Contracts;
using MediatR;

namespace Jookli.Administrator.Application.Configuration.Query
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
