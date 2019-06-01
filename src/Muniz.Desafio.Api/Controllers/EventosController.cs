using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Contracts;
using System.Threading.Tasks;
using Muniz.Desafio.Domain.Queries.Query;
using Muniz.Desafio.Domain.Queries.QueryHandler;
using Muniz.Desafio.Domain.Queries.Results;
using Muniz.Desafio.Domain.Queries.Results.Evento;

namespace Muniz.Desafio.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        readonly IMessengerStorage _messenger;
        private readonly EventoQueryHandler _eventoQuery;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messenger"></param>
        /// <param name="eventoQuery"></param>
        public EventosController(IMessengerStorage messenger, EventoQueryHandler eventoQuery)
        {
            _messenger = messenger;
            _eventoQuery = eventoQuery;
        }

        /// <summary>
        /// Endpoint para registrar os eventos dos sensores
        /// </summary>
        /// <param name="entrada">
        /// Informações do sensor
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public Task Post([FromBody] CriarEventoCommand entrada)
        {
            return _messenger.SendQueueAsync(entrada);
        }

        /// <summary>
        /// Retorna todos os eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public Task<IEnumerable<EventoResult>> Get()
        {
            return Task.FromResult(_eventoQuery.Execute(new ListarTodosQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="exibirPorPagina"></param>
        /// <returns></returns>
        [HttpGet("abc")]
        public Task<ResultPage<EventoResult>> GetPage(int pagina, int exibirPorPagina)
        {
            return Task.FromResult(_eventoQuery.Execute(new ListarTodosPorPaginaQuery(pagina, exibirPorPagina)));
            //    null

            //    );
        }
    }
}