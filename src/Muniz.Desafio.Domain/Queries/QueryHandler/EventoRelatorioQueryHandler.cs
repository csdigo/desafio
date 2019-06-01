using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Domain.Queries.Query;
using Muniz.Desafio.Domain.Queries.Results.EventoRelatorio;

namespace Muniz.Desafio.Domain.Queries.QueryHandler
{
    public class EventoRelatorioQueryHandler :
        IQueryHandler<EventosUltimaHoraQuery, EventosUltimaHoraResult>
    {
        IEventosRelatorioRepository _repository;
        public EventoRelatorioQueryHandler(IEventosRelatorioRepository repository)
        {
            _repository = repository;
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
    }
}
