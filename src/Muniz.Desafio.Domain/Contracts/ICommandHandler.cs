namespace Muniz.Desafio.Domain.Contracts
{
    public interface ICommandHandler<Command> where Command : ICommand
    {
        void Handle(Command command);
    }
}
