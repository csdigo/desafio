using MassTransit;
using Muniz.Desafio.Domain.Commands.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muniz.Desafio.Infra.Mapping.RabbitMq
{
    interface IEventoConsumer : IConsumer<CriarEventoCommand>
    {
    }
}
