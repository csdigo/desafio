using System.Collections.Generic;
using Muniz.Desafio.Domain.Queries.Results.EventoRelatorio;

namespace Muniz.Desafio.Domain.Contracts.Repositories
{
    public interface IEventosRelatorioRepository
    {
        long QuantidadeEventosUltimaHora();
    }
}
