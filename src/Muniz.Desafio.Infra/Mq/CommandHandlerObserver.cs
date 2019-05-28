using MassTransit;
using System;
using System.Threading.Tasks;

namespace Muniz.Desafio.Infra.Mq
{
    public class CommandHandlerObserver : IReceiveEndpointObserver
    {
        public Task Completed(ReceiveEndpointCompleted completed)
        {
            throw new NotImplementedException();
        }

        public Task Faulted(ReceiveEndpointFaulted faulted)
        {
            throw new NotImplementedException();
        }

        public Task Ready(ReceiveEndpointReady ready)
        {
            throw new NotImplementedException();
        }
    }
}
