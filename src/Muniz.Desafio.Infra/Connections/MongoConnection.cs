using MongoDB.Driver;
using Muniz.Desafio.Infra.Mapping.Mongo;

namespace Muniz.Desafio.Infra.Connections
{
    public class MongoConnection
    {
        public IMongoDatabase Conexao;
        public MongoConnection(string connectionString, string database)
        {
            var cliente = new MongoClient(connectionString);
            
            Conexao = cliente.GetDatabase(database);

            // Mapeamento do banco

            new EventoMap();
        }

        
    }
}
