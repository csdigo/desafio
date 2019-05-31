using Muniz.Desafio.Domain.Queries.Query;
using Muniz.Desafio.Domain.Queries.Results;

namespace Muniz.Desafio.Domain.Queries.QueryHandler
{
    public class EventoReportQueryHandler : IQueryHandler<SensoresRegistradosQuery, SensoresRegistradosResult>
    {
        public SensoresRegistradosResult Execute(SensoresRegistradosQuery query)
        {
            SensoresRegistradosResult result = new SensoresRegistradosResult();

            return result;
        }
    }
}
