using System.Collections.Generic;
using Muniz.Desafio.Domain.Queries.Results;

namespace Muniz.Desafio.Domain.Contracts
{
    public interface IQueryHandlerListPage<TQuery, TResult>
        where TQuery : IQueryPage
        where TResult : IResult
    {
        ResultPage<TResult> Execute(TQuery query);
    }
}