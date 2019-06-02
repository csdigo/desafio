using Muniz.Desafio.Domain.Contracts;

namespace Muniz.Desafio.Domain.Queries.Results
{
    public class ResumoPorTagResult : IResult
    {
        public ResumoPorTagResult(string sessao, int quantidade)
        {
            Sessao = sessao;
            Quantidade = quantidade;
        }

        public string Sessao { get; set; }

        public int Quantidade { get; set; }
    }
}
