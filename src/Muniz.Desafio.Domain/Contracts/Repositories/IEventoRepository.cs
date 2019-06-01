using Muniz.Domain.Desafio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Muniz.Desafio.Domain.Contracts.Repositories
{
    public interface IEventoRepository : IRepository
    {
        Task InserirAsync(Evento evento);
        Evento BuscarTimestampETag(long timestamp, string tag);
        IEnumerable<Evento> Todos();
    }
}
