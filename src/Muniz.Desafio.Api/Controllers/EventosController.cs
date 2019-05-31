using Microsoft.AspNetCore.Mvc;
using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Contracts;
using System.Threading.Tasks;

namespace Muniz.Desafio.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        IMessengerStorage _messenger;
        public EventosController(IMessengerStorage messenger)
        {
            _messenger = messenger;
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
        public Task Get()
        {
            return null;
        }
    }
}