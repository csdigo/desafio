using MongoDB.Driver;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Infra.Connections;
using Muniz.Domain.Desafio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;

namespace Muniz.Desafio.Infra.Repositories
{
    public class EventosRelatorioRepository : IEventosRelatorioRepository
    {
        MongoConnection _banco;

        public EventosRelatorioRepository(MongoConnection banco)
        {
            _banco = banco;
        }



        public long QuantidadeEventosUltimaHora()
        {
            return _banco
                .Conexao
                .GetCollection<Evento>("Eventos")
               .CountDocuments(x => x.Recebimento >= DateTime.Now.AddHours(-1));
        }

        public IEnumerable<Domain.ValuesObjects.Tag> RetornarQuantidadeEventoAgrupadoPorTag()
        {
            return _banco
               .Conexao
               .GetCollection<Evento>("Eventos")
              .Find(x => true)
              .ToList()
              // TODO Alterar para retornar direto do banco só a tag
              .Select(x => x.ArtoveTag).ToList();
        }

    }
}
