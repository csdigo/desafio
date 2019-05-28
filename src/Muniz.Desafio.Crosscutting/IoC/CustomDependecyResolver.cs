using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Infra.Connections;
using Muniz.Desafio.Infra.Mq;
using Muniz.Infra.Repositories;
using SimpleInjector;

namespace Muniz.Desafio.Crosscutting.IoC
{
    public class CustomDependecyResolver
    {
        public static void Resolve(Container container)
        {
            container.Register<IEventoRepository, EventoRepository>();
            container.RegisterInstance(new MongoConnection("mongodb://localhost", "desafio"));
            // TODO configurar corretamente
            container.RegisterSingleton<IMessengerStorage>(new MessengerStorage("rabbitmq://localhost"));
        }
    }
}
