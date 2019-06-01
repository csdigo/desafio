using System.Collections.Generic;

namespace Muniz.Desafio.Domain.Contracts
{
    public interface IQueryHandlerList<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        IEnumerable<TResult> Execute(TQuery query);
    }
}