using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CoolService.Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CoolService)))
            {
                host.Open();
                Console.WriteLine("Started working"));
                Console.Read();
            }
        }
    }
}
