using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
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

        public Evento BuscarTimestampETag(long timestamp, string tag)
        {
            return _banco
               .Conexao
                .GetCollection<Evento>("Eventos")
                .Find(x => x.Timestamp == timestamp && x.Tag == tag).FirstOrDefault();
        }

        public IEnumerable<Evento> ListarTodos()
        {
            var result = _banco
               .Conexao
                .GetCollection<Evento>("Eventos")
                .Find(e => true)
                .ToEnumerable();

            return result;
        }

        public IEnumerable<Evento> ListarTodosPorPagina(int pagina, int quantidadePorPagina, out long total)
        {
            total = _banco
                .Conexao
                .GetCollection<Evento>("Eventos")
                .CountDocuments(x => true);


            return _banco
                .Conexao
                .GetCollection<Evento>("Eventos")
                .Find(e => true).Skip(pagina).Limit(quantidadePorPagina)
                .ToEnumerable();


        }


    }
}
