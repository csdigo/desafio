﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public Task Post([FromBody] CriarEventoCommand command)
        {
            return _messenger.SendQueueAsync(command);
        }
    }
}