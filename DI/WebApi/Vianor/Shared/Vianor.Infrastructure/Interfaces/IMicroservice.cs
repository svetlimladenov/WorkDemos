using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vianor.Infrastructure
{
    public interface IMicroservice
    {
        void Start();

        void Setup();

        void Stop();
    }
}
