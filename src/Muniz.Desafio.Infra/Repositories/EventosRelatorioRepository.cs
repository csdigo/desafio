using MongoDB.Driver;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Infra.Connections;
using Muniz.Domain.Desafio.Entities;
using System;
using System.Collections.Generic;
using Muniz.Desafio.Domain.Queries.Results.EventoRelatorio;
using Muniz.Domain.Desafio.Enums;

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

        
    }
}
