using Muniz.Domain.Desafio.Entities;

namespace Muniz.Domain.Desafio.Contracts.Repositories
{
    public interface IEventoRepository
    {
        void Insert(Evento evento);
    }
}
