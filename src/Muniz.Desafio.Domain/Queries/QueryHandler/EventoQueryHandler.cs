using System.Collections.Generic;
using System.Linq;
using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Domain.Queries.Query;
using Muniz.Desafio.Domain.Queries.Results;
using Muniz.Desafio.Domain.Queries.Results.Evento;

namespace Muniz.Desafio.Domain.Queries.QueryHandler
{
    public class EventoQueryHandler :
        IQueryHandlerList<ListarTodosQuery, EventoResult>,
        IQueryHandlerListPage<ListarTodosPorPaginaQuery, EventoResult>
    {
        private IEventoRepository _repository;

        public EventoQueryHandler(IEventoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os eventos registrados
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<EventoResult> Execute(ListarTodosQuery query)
        {
            return _repository
                .ListarTodos()
                .Select(
                    x => new EventoResult(x)
                );
        }

        public ResultPage<EventoResult> Execute(ListarTodosPorPaginaQuery query)
        {
            var result = _repository
                .ListarTodosPorPagina(query.Page, query.Show, out long total)
                .Select(
                    x => new EventoResult(x)
                );

            return new ResultPage<EventoResult>(total, result);
      

               

        }
    }
}
