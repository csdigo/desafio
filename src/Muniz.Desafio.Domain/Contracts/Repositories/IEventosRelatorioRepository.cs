using System.Collections.Generic;

namespace Muniz.Desafio.Domain.Contracts.Repositories
{
    public interface IEventosRelatorioRepository
    {
        long QuantidadeEventosUltimaHora();

        IEnumerable<Domain.ValuesObjects.Tag> RetornarQuantidadeEventoAgrupadoPorTag();
    }
}
