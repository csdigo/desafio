using System.Threading.Tasks;

namespace Muniz.Desafio.Domain.Contracts
{
    public interface IMessengerStorage
    {
        Task SendQueueAsync<Command>(Command command)
            where Command : class;


    }
}
