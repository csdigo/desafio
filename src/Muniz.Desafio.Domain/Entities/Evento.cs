using Muniz.Domain.Desafio.Enums;
using System;

namespace Muniz.Domain.Desafio.Entities
{
    public class Evento
    {
        #region Constrututores 

        public Evento(string tag, string valor, long timeStamp)
        {
            Id = Guid.NewGuid();
            
            // Data e hora que o evento foi processado
            Registrado = DateTime.Now;

            EventoEstado = EventoEstado.Processado;
            Timestamp = timeStamp;

            // Convertendo a data TimeStamp para Data e hora
            DataHoraSensor = new DateTime(timeStamp, DateTimeKind.Utc);

            // Verificando se o tipo do evento é numérico
            EventoTipo = int.TryParse(valor, out _) ? EventoTipo.Numero : EventoTipo.Texto;

            // Verificando se o valor é erro
            if (string.IsNullOrEmpty(valor))
                EventoEstado = EventoEstado.Erro;
        }

        #endregion

        #region Propriedades

        public Guid Id { get; }

        public string Tag { get; }

        public string Valor { get; }

        public DateTime Registrado { get; }

        public DateTime DataHoraSensor { get; }

        public long Timestamp { get; }

        public EventoEstado EventoEstado { get; }

        public EventoTipo EventoTipo { get; }

        #endregion
    }
}