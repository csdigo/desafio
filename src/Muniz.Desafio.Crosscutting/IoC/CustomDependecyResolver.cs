
using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Domain.Contracts.Repositories;
using Muniz.Desafio.Infra.Connections;
using Muniz.Desafio.Infra.Mq;
using Muniz.Infra.Repositories;
using SimpleInjector;
using Muniz.Desafio.Domain.Commands.CommandHandler;
using MassTransit;
using System;
using Muniz.Desafio.Domain.Queries.QueryHandler;
using Muniz.Desafio.Infra.Repositories;

namespace Muniz.Desafio.Crosscutting.IoC
{
    public class CustomDependecyResolver
    {
        public static void Resolve(Container container)
        {
            container.Register<IEventoRepository, EventoRepository>();
            container.Register<IEventosRelatorioRepository, EventosRelatorioRepository>();


            container.Register<EventoCommandHandler>();
            container.Register<RelatorioEventoQueryHandler>();
            container.Register<EventoQueryHandler>();


            // TODO configurar corretamente
            container.RegisterInstance(new MongoConnection("mongodb://localhost", "desafio"));

            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var a = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");

                });


            });
            container.RegisterInstance(bus);
            container.RegisterSingleton<IMessengerStorage, MessengerStorage>();
        }
    }
}
