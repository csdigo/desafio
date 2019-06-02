using MassTransit;
using Muniz.Desafio.Domain.Commands.Command;
using System;

namespace Muniz.Desafio.Infra.Mapping.RabbitMq
{
    public class EndpointMap
    {
        public EndpointMap()
        {
            EndpointConvention.Map<CriarEventoCommand>(
            new Uri("rabbitmq://localhost/Evento")); // Todo mudar

        }
    }
}
