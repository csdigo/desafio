using Muniz.Domain.Desafio.Enums;
using System;

namespace Muniz.Domain.Desafio.Entities
{
    public class Evento
    {
        #region Constrututores 

        public Evento(string tag, string valor, long timeStamp, DateTime dataRecebimento)
        {
            // TODO Mudar o ID
            Id = Guid.NewGuid();

            Tag = tag;
            Valor = valor;

            // 
            Registrado = DateTime.Now;
            Recebimento = dataRecebimento;

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

        /// <summary>
        /// Data e hora que o evento foi processado
        /// </summary>
        public DateTime Registrado { get; }

        /// <summary>
        /// Data e hora que o evento foi recebido
        /// </summary>
        public DateTime Recebimento { get; }

        public DateTime DataHoraSensor { get; }

        public long Timestamp { get; }

        public EventoEstado EventoEstado { get; }

        public EventoTipo EventoTipo { get; }

        #endregion
    }
}