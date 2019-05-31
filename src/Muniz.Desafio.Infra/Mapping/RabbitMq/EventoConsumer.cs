using MassTransit;
using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Commands.CommandHandler;
using System;
using System.Threading.Tasks;

namespace Muniz.Desafio.Infra.Mapping.RabbitMq
{
    public class EventoConsumer : IConsumer<CriarEventoCommand>
    {
        private readonly EventoCommandHandler _commandHandler;

        public EventoConsumer(EventoCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }
        public Task Consume(ConsumeContext<CriarEventoCommand> context)
        {
            return Task.Run(() =>
            {
                _commandHandler.Handle(context.Message);
                Console.WriteLine($"Mensagem consumida : " + context.Message.Timestamp);
            });

        }
    }
}
