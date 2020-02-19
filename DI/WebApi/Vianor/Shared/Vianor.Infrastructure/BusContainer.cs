using EasyNetQ;

namespace Vianor.Infrastructure
{
    public class BusContainer : IBusContainer
    {
        public IBus CreateBus()
        {
            return RabbitHutch.CreateBus("host=localhost");
        }
    }
}