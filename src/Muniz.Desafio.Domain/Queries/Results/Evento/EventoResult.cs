using System;
using Muniz.Desafio.Domain.Contracts;

namespace Muniz.Desafio.Domain.Queries.Results.Evento
{
    public class EventoResult : IResult
    {

        public EventoResult(Muniz.Domain.Desafio.Entities.Evento evento)
        {
            // Todo Usar o autoMapper

            Id = evento.Id;
            Tag = evento.Tag;
            Valor = evento.Valor;
            Registrado = evento.Registrado;
            Recebimento = evento.Recebimento;
            DataHoraSensor = evento.DataHoraSensor;
            Timestamp = evento.Timestamp;
            Estado = evento.EventoEstado.ToString();
            Tipo = evento.EventoTipo.ToString();

        }

        public Guid Id { get; set; }

        public string Tag { get; set; }

        public string Valor { get; set; }

        public DateTime Registrado { get; set; }

        public DateTime Recebimento { get; set; }

        public DateTime DataHoraSensor { get; set; }

        public long Timestamp { get; set; }

        public string Estado { get; set; }

        public string Tipo { get; set; }
    }
}
