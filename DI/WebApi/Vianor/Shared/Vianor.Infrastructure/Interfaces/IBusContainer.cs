using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;

namespace Vianor.Infrastructure
{
    public interface IBusContainer
    {
        IBus GetBus();
    }   
}
