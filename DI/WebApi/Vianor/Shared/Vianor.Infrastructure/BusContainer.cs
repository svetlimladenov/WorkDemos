using EasyNetQ;

namespace Vianor.Infrastructure
{
    public class BusContainer : IBusContainer
    {
        private readonly IBus bus;

        public BusContainer()
        {
            bus = BusFactory.CreateBus();
        }

        public IBus GetBus()
        {
            return this.bus;
        }
    }
}