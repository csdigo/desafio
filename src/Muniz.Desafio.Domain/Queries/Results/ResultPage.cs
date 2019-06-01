using System.Collections.Generic;
using Muniz.Desafio.Domain.Contracts;

namespace Muniz.Desafio.Domain.Queries.Results
{
    public class ResultPage<TResult> where TResult : IResult
    {
        public ResultPage(long total, IEnumerable<TResult> results)
        {
            Total = total;
            Results = results;
        }
        public long Total { get;  }
        public IEnumerable<TResult> Results { get; }
    }
}
