namespace Muniz.Desafio.Domain.Contracts
{
    public interface IMessengerStorage 
    {
        void SendQueueAsync(ICommand command);
    }
}
