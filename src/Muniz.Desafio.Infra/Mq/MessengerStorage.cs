using MassTransit;
using Muniz.Desafio.Domain.Commands.Command;
using Muniz.Desafio.Domain.Contracts;
using Muniz.Desafio.Infra.Mapping.RabbitMq;
using System;
using System.Threading.Tasks;

namespace Muniz.Desafio.Infra.Mq
{
    public class MessengerStorage : IMessengerStorage
    {
        private IBusControl _bus;
        private string host;

        public MessengerStorage(string host, string username = "guest", string password = "guest")
        {
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
        public async void SendQueueAsync<Command>(Command command)
            where Command : class

        {
            await _bus.Send(command);
        }


    }
}
