
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

        public MessengerStorage(string host, string username = "guest", string password = "guest")
        {
            _host = host;
            _username = username;
            _password = password;

            _bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var a = sbc.Host(new Uri(host), h =>
                {
                    h.Username(username);
                    h.Password(password);

                });

            });

            _bus.Start();

            new EndpointMap();
        }

        public void ListenQueueAsync<Command>() where Command : class
        {
            //var consumer = container.GetInstance<IEventoConsumer>();
            _bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var a = sbc.Host(new Uri(_host), h =>
                {
                    h.Username(_username);
                    h.Password(_password);
                    

                });
                a.ConnectReceiveEndpoint("evento", x =>
                {
                    
                   
                });
            });

            _bus.Start();
        }

        public  void SendQueueAsync<Command>(Command command)
            where Command : class

        {
            _bus.Send(command);
            Console.WriteLine("Enviando Pra Fila");
        }


    }
}
