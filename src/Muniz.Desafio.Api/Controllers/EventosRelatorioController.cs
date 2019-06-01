using Microsoft.AspNetCore.Mvc;
using Muniz.Desafio.Domain.Queries.Query;
using Muniz.Desafio.Domain.Queries.QueryHandler;

namespace Muniz.Desafio.Api.Controllers
{
    /// <summary>
    /// Relatórios e metricas dos eventos recebidos pelos sensores
    /// </summary>
    [Route("api/Eventos/Relatorio")]
    [ApiController]
    public class EventosRelatorioController : ControllerBase
    {
        private readonly EventoRelatorioQueryHandler _queryHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryHandler"></param>
        public EventosRelatorioController(EventoRelatorioQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Quantidade de eventos recebidos na ultima hora
        /// </summary>
        /// <returns></returns>
        [HttpGet("QtdRecebidosUltimaHora")]
        public  long Get()
        {
            var result =_queryHandler.Execute(new EventosUltimaHoraQuery());

            return result.Quantidade;
        }
    }
}