using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vianor.Infrastructure;

namespace Vianor.MS.Order.Runner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var scope = ContainerFactory.CreateLifetimeScope())
            {
                var microserviceContainer = MicroserviceContainerFactory.Create(scope);

                new TopShelfRunner(microserviceContainer).Run();
            }
        }
    }
}
