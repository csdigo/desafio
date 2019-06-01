using Microsoft.AspNetCore.Mvc;
using Muniz.Desafio.Domain.Queries.Query;
using Muniz.Desafio.Domain.Queries.QueryHandler;

namespace Muniz.Desafio.Api.Controllers
{
    /// <summary>
    /// Relatórios e metricas dos eventos recebidos pelos sensores
    /// </summary>
    [Route("api/RelatoriosEventos/")]
    [ApiController]
    public class RelatoriosEventosController : ControllerBase
    {
        private readonly RelatorioEventoQueryHandler _queryHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryHandler"></param>
        public RelatoriosEventosController(RelatorioEventoQueryHandler queryHandler)
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