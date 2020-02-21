using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Vianor.Infrastructure.Interfaces;

namespace Vianor.Infrastructure
{
    public class MicroserviceContainerFactory
    {
        public static IMicroserviceContainer Create(ILifetimeScope container)
        {
            var microservice = container.Resolve<IMicroservice>();
            return new MicroserviceContainerIoC(microservice);
        }
    }
}
