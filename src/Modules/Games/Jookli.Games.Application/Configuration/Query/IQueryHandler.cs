using Jookli.Games.Application.Contracts;
using MediatR;

namespace Jookli.Games.Application.Configuration.Query
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
