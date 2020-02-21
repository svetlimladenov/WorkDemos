using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vianor.Infrastructure;

namespace Vianor.MS.Order
{
    public class OrderMicroservice : MicroserviceBase
    {
        public OrderMicroservice(IBus bus) : base(bus)
        {
        }

        public override void Setup()
        {
            RespondAsync()
        }
    }
}
