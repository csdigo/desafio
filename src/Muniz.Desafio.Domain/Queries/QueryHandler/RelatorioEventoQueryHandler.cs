using System.Collections.Generic;
using System.Linq;
using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Domain.Queries.Query;
using Muniz.Desafio.Domain.Queries.Query.EventoRelatorio;
using Muniz.Desafio.Domain.Queries.Results.EventoRelatorio;

namespace Muniz.Desafio.Domain.Queries.QueryHandler
{
    public class RelatorioEventoQueryHandler :
        IQueryHandler<EventosUltimaHoraQuery, EventosUltimaHoraResult>,
        IQueryHandlerList<EventosTipoNumeroPorTagEDataQuery, EventosTipoNumeroPorTagEDataResult>
    {
        IEventosRelatorioRepository _repository;
        IEventoRepository _repositoryEvento;
        public RelatorioEventoQueryHandler(IEventosRelatorioRepository repository, IEventoRepository repositoryEvento)
        {
            _repository = repository;
            _repositoryEvento = repositoryEvento;
        }

        /// <summary>
        /// Retorna a média de movimentos por hora
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public EventosUltimaHoraResult Execute(EventosUltimaHoraQuery query)
        {
            return new EventosUltimaHoraResult() { Quantidade = _repository.QuantidadeEventosUltimaHora() };
        }


        public IEnumerable<EventosTipoNumeroPorTagEDataResult> Execute(EventosTipoNumeroPorTagEDataQuery query)
        {
            return _repositoryEvento.BuscarPorTipoNumerico().Select(x=> new EventosTipoNumeroPorTagEDataResult(x));
        }
    }
}
