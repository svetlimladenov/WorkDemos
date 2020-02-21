using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vianor.Infrastructure.Interfaces;

namespace Vianor.Infrastructure
{
    public class MicroserviceContainerIoC : IMicroserviceContainer
    {
        private readonly IMicroservice microservice;

        public MicroserviceContainerIoC(IMicroservice microservice)
        {
            this.microservice = microservice;
        }

        public void Setup()
        {
            this.microservice.Setup();
        }

        public void Start()
        {
            this.microservice.Start();
        }

        public void Stop()
        {
            this.microservice.Start();
        }
    }
}
