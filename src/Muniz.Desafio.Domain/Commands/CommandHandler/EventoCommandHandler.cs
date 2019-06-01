using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Domain.Desafio.Entities;

namespace Muniz.Desafio.Domain.Commands.CommandHandler
{
    public class EventoCommandHandler : ICommandHandler<CriarEventoCommand>
    {
        private readonly IEventoRepository _repository;

        public EventoCommandHandler(IEventoRepository repository)
        {
            _repository = repository;
        }
        public void Handle(CriarEventoCommand command)
        {
            var evento = new Evento(command.Tag, command.Valor, command.Timestamp, command.DataRecebimento);

            // idempotência 
            if (_repository.BuscarTimestampETag(evento.Timestamp, evento.Tag) != null)
                return; // Já foi processado

            _repository.InserirAsync(evento);
        }
    }
}
