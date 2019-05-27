using System.Threading.Tasks;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Infra.Connections;
using Muniz.Domain.Desafio.Entities;

namespace Muniz.Infra.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private MongoConnection _banco;
        public EventoRepository(MongoConnection banco)
        {
            _banco = banco;
        }
        public Task InserirAsync(Evento evento)
        {
            return _banco
               .Conexao
                .GetCollection<Evento>("Eventos")
                .InsertOneAsync(evento);
        }
    }
}
