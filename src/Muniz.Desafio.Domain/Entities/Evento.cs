using Muniz.Desafio.Domain.ValuesObjects;
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

            Tag = tag?.ToLower();
            ArtoveTag = new Tag(Tag);

            Valor = valor;

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

        public Guid Id { get; private set; }

        public string Tag { get; private set; }

        public Tag ArtoveTag { get; private set; }

        public string Valor { get; private set; }

        /// <summary>
        /// Data e hora que o evento foi processado
        /// </summary>
        public DateTime Registrado { get; private set; }

        /// <summary>
        /// Data e hora que o evento foi recebido
        /// </summary>
        public DateTime Recebimento { get; private set; }

        public DateTime DataHoraSensor { get; private set; }

        public long Timestamp { get; private set; }

        public EventoEstado EventoEstado { get; private set; }

        public EventoTipo EventoTipo { get; private set; }

        #endregion
    }
}