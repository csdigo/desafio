namespace Muniz.Desafio.Domain.Contracts
{
    public interface IMessengerStorage
    {
        void SendQueueAsync<Command>(Command command)
            where Command : class;
    }
}
