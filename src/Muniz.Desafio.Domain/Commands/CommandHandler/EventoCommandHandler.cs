using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Domain.Desafio.Entities;

namespace Muniz.Desafio.Domain.Commands.CommandHandler
{
    public class EventoCommandHandler : ICommandHandler<CriarEventoCommand>
    {
        private readonly IEventoRepository _repository;
        IMessengerStorage _messenger;

        public EventoCommandHandler(IEventoRepository repository, IMessengerStorage messenger)
        {
            _repository = repository;
            _messenger = messenger;
        }
        public void Handle(CriarEventoCommand command)
        {
            var evento = new Evento(command.Tag, command.Valor, command.Timestamp, command.DataRecebimento);

            // idempotência 
            if (_repository.BuscarPorTimestampETag(evento.Timestamp, evento.Tag) != null)
                return; // Já foi processado

            _repository.InserirAsync(evento);

        }
    }
}
