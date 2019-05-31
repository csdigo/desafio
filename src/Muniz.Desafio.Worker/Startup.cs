using Muniz.Desafio.Crosscutting.IoC;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using MassTransit;
using Muniz.Desafio.Infra.Mapping.RabbitMq;
using System;

namespace Muniz.Desafio.Worker
{
    public class Startup
    {
        public static void Init()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            CustomDependecyResolver.Resolve(container);

            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var a = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");

                });

                a.ConnectReceiveEndpoint("Evento", x =>
                {
                    x.Consumer<EventoConsumer>(container);
                });

            });

            
            bus.Start();

        }
    }
}
