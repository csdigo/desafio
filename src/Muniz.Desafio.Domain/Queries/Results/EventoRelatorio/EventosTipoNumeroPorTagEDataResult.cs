using System;
using Muniz.Desafio.Domain.Contracts;
using Muniz.Domain.Desafio.Entities;

namespace Muniz.Desafio.Domain.Queries.Results.EventoRelatorio
{
    public class EventosTipoNumeroPorTagEDataResult : IResult
    {

        public EventosTipoNumeroPorTagEDataResult(Muniz.Domain.Desafio.Entities.Evento e)
        {
            Tag = e.Tag;
            Data = e.DataHoraSensor.Date; // Pegando apenas a data
            Valor = int.Parse(e.Valor);
        }

        public DateTime Data { get; set; }
        public string Tag { get; set; }

        public long Valor { get; set; }
    }
}
