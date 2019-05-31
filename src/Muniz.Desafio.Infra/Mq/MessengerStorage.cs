
using MassTransit;
using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Infra.Mapping.RabbitMq;
using SimpleInjector;
using System;

namespace Muniz.Desafio.Infra.Mq
{
    public class MessengerStorage : IMessengerStorage
    {
        private IBusControl _bus;
        private string _host;
        private string _username;
        private string _password;

        public MessengerStorage(IBusControl bus)
        {
            _bus = bus;
            
            new EndpointMap();
        }

        // TODO Colocar o Listen no mensageiro

        public void SendQueueAsync<Command>(Command command)
            where Command : class

        {
            _bus.Send(command);
        }


    }
}
