using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.HostConfigurators;
using Vianor.Infrastructure.Interfaces;

namespace Vianor.Infrastructure
{
    public class TopShelfRunner
    {
        private const int DelayInMinutes = 1;
        private readonly IMicroserviceContainer microserviceContainer;

        public TopShelfRunner(IMicroserviceContainer microserviceContainer)
        {
            this.microserviceContainer = microserviceContainer;
        }

        public void Run()
        {
            Host host = HostFactory.New(hostConfig =>
            {
                hostConfig.EnableServiceRecovery(recoveryConfig =>
                {
                    recoveryConfig.RestartService(DelayInMinutes);
                });

                hostConfig.OnException(ex =>
                {
                   //TODO: Log exception
                });

                hostConfig.Service<IMicroserviceContainer>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(() =>
                    {
                        microserviceContainer.Setup();
                        return microserviceContainer;
                    });
                    serviceConfig.WhenStarted(container => container.Start());
                    serviceConfig.WhenStopped(container => container.Stop());
                });

                hostConfig.RunAsLocalService();

                SetServiceConfigurationInfo(hostConfig);
            });

            host.Run();
        }

        private void SetServiceConfigurationInfo(HostConfigurator hostConfig)
        {
            var serviceName = "Order Microservice";
            var displayName = "Order MS";
            hostConfig.SetServiceName(serviceName);
        }
    }
}
