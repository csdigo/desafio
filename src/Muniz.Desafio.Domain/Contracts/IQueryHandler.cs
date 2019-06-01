namespace Muniz.Desafio.Domain.Contracts
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        TResult Execute(TQuery query);
    }
}
