using Muniz.Desafio.Domain.Contracts;
using System.Threading.Tasks;

namespace Muniz.Desafio.Infra.Mq
{
    public class MessengerStorage : IMessengerStorage
    {
        public void SendQueueAsync(ICommand command)
        {
            Task.Run(
                () =>
                {
                    // TODO implementar enviar para fila
                }
            );

            
        }
    }
}
