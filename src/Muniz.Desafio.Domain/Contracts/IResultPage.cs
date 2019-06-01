using System.Collections.Generic;

namespace Muniz.Desafio.Domain.Contracts
{
    public interface IResultPage<TResult>
    where TResult : IResult
    {
        int Total { get; set; }
        IEnumerable<TResult> Results { get; set; }
    }
}