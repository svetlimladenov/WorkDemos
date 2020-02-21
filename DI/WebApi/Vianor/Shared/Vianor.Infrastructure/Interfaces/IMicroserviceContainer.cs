using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vianor.Infrastructure.Interfaces
{
    public interface IMicroserviceContainer
    {
        void Setup();

        void Start();

        void Stop();
    }
}
