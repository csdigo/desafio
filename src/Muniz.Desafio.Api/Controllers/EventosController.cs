using Microsoft.AspNetCore.Mvc;
using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Contracts;

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

        [HttpPost]
        public void Post([FromBody] CriarEventoCommand command)
        {
            _messenger.SendQueueAsync(command);
        }
    }
}