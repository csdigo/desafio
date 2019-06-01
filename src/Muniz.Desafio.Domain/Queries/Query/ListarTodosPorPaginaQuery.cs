using System;
using System.Collections.Generic;
using System.Text;
using Muniz.Desafio.Domain.Contracts;

namespace Muniz.Desafio.Domain.Queries.Query
{
    public class ListarTodosPorPaginaQuery : IQueryPage
    {
        public ListarTodosPorPaginaQuery(int pagina = 1, int quantidadePorPagina = 10)
        {
            // TODO colocar em uma classe pai 
            Page = (pagina -1) * quantidadePorPagina;
            Show = quantidadePorPagina;
        }


        public int Page { get; set; }
        public int Show { get; set; }

    }
}
