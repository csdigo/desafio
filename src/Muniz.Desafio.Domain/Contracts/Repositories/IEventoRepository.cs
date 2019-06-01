using Muniz.Domain.Desafio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Muniz.Desafio.Domain.Queries.Results.EventoRelatorio;

namespace Muniz.Desafio.Domain.Contracts.Repositories
{
    public interface IEventoRepository : IRepository
    {
        Task InserirAsync(Evento evento);
        Evento BuscarPorTimestampETag(long timestamp, string tag);
        IEnumerable<Evento> ListarTodos();

        IEnumerable<Evento> ListarTodosPorPagina(int pagina, int quantidadePorPagina, out long total);
        IEnumerable<Evento> BuscarPorTipoNumerico();
    }
}
