using EasyNetQ;

namespace Vianor.MS.Order
{
    public abstract class BaseMicroservice 
    {
        public IBus Bus { get; set; }

        public BaseMicroservice()
        {
            this.Bus = RabbitHutch.CreateBus();
        }
    }
}