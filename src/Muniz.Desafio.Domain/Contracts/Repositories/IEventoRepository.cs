using Muniz.Domain.Desafio.Entities;
using System.Threading.Tasks;

namespace Muniz.Desafio.Domain.Contracts.Repositories
{
    public interface IEventoRepository : IRepository
    {
        Task InserirAsync(Evento evento);
        Evento BuscarPorId(long id);
    }
}
