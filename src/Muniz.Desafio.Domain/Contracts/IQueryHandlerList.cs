using System.Collections.Generic;

namespace Muniz.Desafio.Domain.Contracts
{
    public interface IQueryHandlerList<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IEnumerable<IResult>
    {
        TResult Execute(TQuery query);
    }
}