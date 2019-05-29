using Muniz.Desafio.Crosscutting.IoC;
using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Contracts;
using SimpleInjector;

namespace Muniz.Desafio.Worker
{
    public class Startup
    {
        public static void Init()
        {
            var container = new Container();
            CustomDependecyResolver.Resolve(container);

            var messeger = container.GetInstance<IMessengerStorage>();

            // Consumindo os eventos dos sensores
            messeger.ListenQueueAsync<CriarEventoCommand>();
        }
    }
}
