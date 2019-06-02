using System.Collections.Generic;
using System.Linq;
using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Domain.Queries.Query;
using Muniz.Desafio.Domain.Queries.Query.EventoRelatorio;
using Muniz.Desafio.Domain.Queries.Results;
using Muniz.Desafio.Domain.Queries.Results.EventoRelatorio;

namespace Muniz.Desafio.Domain.Queries.QueryHandler
{
    public class RelatorioEventoQueryHandler :
        IQueryHandler<EventosUltimaHoraQuery, EventosUltimaHoraResult>,
        IQueryHandlerList<EventosTipoNumeroPorTagEDataQuery, EventosTipoNumeroPorTagEDataResult>,
        IQueryHandlerList<ResumoPorTagQuery, ResumoPorTagResult>
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
            return _repositoryEvento.BuscarPorTipoNumerico().Select(x => new EventosTipoNumeroPorTagEDataResult(x));
        }

        public IEnumerable<ResumoPorTagResult> Execute(ResumoPorTagQuery query)
        {
            // TODO Alterar pra retornar direto do mongo
            List<ResumoPorTagResult> resumoPorTagResults = new List<ResumoPorTagResult>();
            var resultPorRegiao = _repository.RetornarQuantidadeEventoAgrupadoPorTag().GroupBy(x => new { x.Pais, x.Regiao });
            var resultPorSensores = _repository.RetornarQuantidadeEventoAgrupadoPorTag().GroupBy(x => new { x.Pais, x.Regiao, x.Sensor });

            resumoPorTagResults.AddRange(resultPorRegiao.Select(x => new ResumoPorTagResult($"{x.Key.Pais}.{x.Key.Regiao}", x.Count())));
            resumoPorTagResults.AddRange(resultPorSensores.Select(x => new ResumoPorTagResult($"{x.Key.Pais}.{x.Key.Regiao}.{x.Key.Sensor}", x.Count())));


            return resumoPorTagResults.OrderBy(x => x.Sessao);
        }
    }
}
