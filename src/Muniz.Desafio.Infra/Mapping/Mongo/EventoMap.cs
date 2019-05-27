using MongoDB.Bson.Serialization;
using Muniz.Domain.Desafio.Entities;

namespace Muniz.Desafio.Infra.Mapping.Mongo
{
    public class EventoMap
    {
        public EventoMap()
        {
            BsonClassMap.RegisterClassMap<Evento>(cm => {
                cm.MapIdField(x=> x.Id);
                cm.MapField(x=> x.Registrado);
                cm.MapField(x => x.Tag);
                cm.MapField(x => x.Timestamp);
                cm.MapField(x => x.Valor);
                cm.MapField(x => x.DataHoraSensor);
                cm.MapField(x => x.EventoEstado);
                cm.MapField(x => x.EventoTipo);
            });
        }
    }
}
