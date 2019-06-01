namespace Muniz.Desafio.Domain.Contracts
{
    public interface IQueryPage
    {
        int Page { get; set; }
        int Show { get; set; }
    }
}