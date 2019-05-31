using System;
using System.Collections.Generic;
using System.Text;

namespace Muniz.Desafio.Domain.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        TResult Execute(TQuery query);
    }
}
