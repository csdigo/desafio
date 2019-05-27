using Muniz.Desafio.Infra.Connections;
using Muniz.Domain.Desafio.Entities;

namespace Muniz.Desafio.Infra.Mapping.Mongo
{
    /// <summary>
    /// 
    /// </summary>
    public class Migration
    {
        public Migration(MongoConnection conexao)
        {
            var a = conexao.Conexao.GetCollection<Evento>("Eventos");
        }
    }
}
